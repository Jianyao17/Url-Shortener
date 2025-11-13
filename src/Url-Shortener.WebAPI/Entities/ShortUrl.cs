using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using UrlShortener.WebAPI.Database;

namespace UrlShortener.WebAPI.Entities;

[Index(nameof(ShortCode), IsUnique = true), 
 Index(nameof(IsActive))]
public class ShortUrl : ISoftDeletable
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
    
    [Required, MaxLength(64)]
    public string ShortCode { get; set; } = string.Empty;
    
    [Required, MaxLength(1024), Url]
    public string OriginalUrl { get; set; } = string.Empty;
    
    [Required]
    public bool IsActive { get; set; } = true;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
    
    public ICollection<ShortUrlChange> Changes { get; set; } = new List<ShortUrlChange>();
    public ICollection<ShortUrlClick> Clicks { get; set; } = new List<ShortUrlClick>();
};