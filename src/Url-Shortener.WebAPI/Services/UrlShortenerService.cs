using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Hybrid;
using UrlShortener.WebAPI.Database;
using UrlShortener.WebAPI.Entities;

namespace UrlShortener.WebAPI.Services;

internal sealed class UrlShortenerService(
    ILogger<UrlShortenerService> logger,
    AppDbContext dbContext,
    HybridCache hybridCache)
{
    private const int MaxRetry = 3;
    
    public async Task<string> ShortenUrl(string url)
    {
        for (int attempt = 0; attempt <= MaxRetry; attempt++)
        {
            try
            {   // Generate a unique short code
                var shortCode = GenerateShortCode();
                await dbContext.ShortUrls.AddAsync(new ShortUrl
                {
                    OriginalUrl = url,
                    ShortCode = shortCode,
                    CreatedAt = DateTime.UtcNow
                });
        
                // Save to database and cache
                await dbContext.SaveChangesAsync();
                await hybridCache.SetAsync(shortCode, url);

                return shortCode;
            }
            catch (Exception e)
            {
                // Handle potential collisions or database errors
                if (attempt == MaxRetry)
                {
                    logger.LogError(e, "Failed to shorten URL after {MaxRetry} attempts", MaxRetry);
                    throw new InvalidOperationException("Failed to shorten URL after MaxRetry", e);
                }
                logger.LogWarning(e, 
                    "Collision detected when generating short code. Retrying... Attempt {Attempt}", 
                    attempt + 1);
            }
        }
        throw new InvalidOperationException("Failed to shorten URL after MaxRetry");
    }
    
    public async Task<string?> GetOriginalUrl(string shortCode)
    {
        return await hybridCache.GetOrCreateAsync(shortCode, 
             async cancel =>
            {
                 var shortUrl = await dbContext.ShortUrls
                    .FirstOrDefaultAsync(su => su.ShortCode == shortCode, cancel);

                 return shortUrl?.OriginalUrl;
            });
    }
    
    
    private static string GenerateShortCode()
    {
        const int length = 7;
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        
        return new string(Enumerable.Range(0, length)
            .Select(_ => chars[Random.Shared.Next(chars.Length)])
            .ToArray());
    }
}