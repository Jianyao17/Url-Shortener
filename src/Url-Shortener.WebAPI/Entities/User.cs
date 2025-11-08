using Microsoft.AspNetCore.Identity;

namespace UrlShortener.WebAPI.Entities;

public class User : IdentityUser<Guid>
{
    public ICollection<ShortUrl> ShortUrls { get; set; } = new List<ShortUrl>();
    public ICollection<ShortUrlChange> ShortUrlChanges { get; set; } = new List<ShortUrlChange>();
}