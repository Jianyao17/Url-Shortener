
namespace UrlShortener.WebAPI.Database;

public interface ISoftDeletable
{
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted => DeletedAt.HasValue;
    
    public void Restore()
    {
        DeletedAt = null;
    }
}

