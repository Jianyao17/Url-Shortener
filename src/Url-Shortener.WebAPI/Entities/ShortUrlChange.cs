using System.ComponentModel.DataAnnotations;

namespace UrlShortener.WebAPI.Entities;

public class ShortUrlChange
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
    
    [Required]
    public Guid ShortUrlId { get; set; }
    public ShortUrl ShortUrl { get; set; } = default!;
    
    public string? ShortCodeBefore { get; set; }
    public string? ShortCodeAfter { get; set; }
    public string? OriginalUrlBefore { get; set; }
    public string? OriginalUrlAfter { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}