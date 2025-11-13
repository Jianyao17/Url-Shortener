using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.WebAPI.Database;

public interface ISoftDeletable
{
    public DateTime? DeletedAt { get; set; }
    
    [NotMapped] 
    public bool IsDeleted => DeletedAt.HasValue;
    
    public void Restore()
    {
        DeletedAt = null;
    }
}

