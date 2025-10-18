using UrlShortener.WebAPI.Services;

namespace UrlShortener.WebAPI.Endpoints;

internal static class GetShortenUrl
{
    internal static void MapGetShortenUrlEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/{shortCode}",
            async (string shortCode, UrlShortenerService urlShortenerService) =>
        {
            if (string.IsNullOrWhiteSpace(shortCode))
                return Results.BadRequest("Short code is required.");
            
            var originalUrl = await urlShortenerService.GetOriginalUrl(shortCode);
            return string.IsNullOrEmpty(originalUrl)
                ? Results.NotFound("Short URL not found.")
                : Results.Redirect(originalUrl);
        })
        .WithOpenApi()
        .WithDescription("Retrieves the original URL for the given short code and redirects to it.")
        .WithSummary("Get Original URL")
        .WithName("GetOriginalUrl")
        .WithTags("URL Redirect");
    }
}