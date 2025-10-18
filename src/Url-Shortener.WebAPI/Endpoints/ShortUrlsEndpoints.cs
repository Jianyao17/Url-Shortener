using System.ComponentModel.DataAnnotations;
using UrlShortener.WebAPI.Services;

namespace UrlShortener.WebAPI.Endpoints;

internal static class ShortUrlsEndpoints
{
    private record ShortenUrlRequest(
        [Required, Url, MaxLength(1024)] string OriginalUrl);

    internal static void MapShortUrlsEndpoints(this IEndpointRouteBuilder app)
    {
        var urlManagerGroup = app
            .MapGroup("/api")
            .ProducesValidationProblem()
            .WithOpenApi().WithTags("URLs Manager");

        urlManagerGroup.MapPost("/shorten",
            async (ShortenUrlRequest request, UrlShortenerService urlShortenerService) =>
        {
            if (!Uri.IsWellFormedUriString(request.OriginalUrl, UriKind.Absolute))
                return Results.BadRequest("Invalid URL format.");

            var shortCode = await urlShortenerService.ShortenUrl(request.OriginalUrl);
            return Results.Ok(new { shortCode });
        })
        .WithParameterValidation()
        .WithDescription("Generates a shortened URL for the provided original URL.")
        .WithSummary("Shorten URL")
        .WithName("ShortenUrl");
    }
}