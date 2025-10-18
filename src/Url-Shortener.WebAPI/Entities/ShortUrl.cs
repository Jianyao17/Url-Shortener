using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UrlShortener.WebAPI.Entities;

[Index(nameof(ShortCode), IsUnique = true)]
public class ShortUrl
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required, MaxLength(64)]
    public string ShortCode { get; set; } = string.Empty;
    
    [Required, MaxLength(1024), Url]
    public string OriginalUrl { get; set; } = string.Empty;
    
    [Required]
    public bool IsActive { get; set; } = true;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
};