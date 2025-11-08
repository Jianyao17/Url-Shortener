using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UrlShortener.WebAPI.Entities;

[Index(nameof(ShortUrlId), nameof(ClickedAt)), 
 Index(nameof(Latitude), nameof(Longitude)), 
 Index(nameof(Country)), Index(nameof(City))]
public class ShortUrlClick
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid ShortUrlId { get; set; }
    public ShortUrl ShortUrl { get; set; } = default!;
    
    [Required]
    public DateTime ReferenceAt { get; set; }

    [Required] public String IpAddress { get; set; } = default!;
    [Required] public String UserAgent { get; set; } = default!;
    
    public string? Country { get; set; }
    public string? City { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    
    public DateTime ClickedAt { get; set; } = DateTime.UtcNow;
}