using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UrlShortener.WebAPI.Entities;

namespace UrlShortener.WebAPI.Database;

internal class AppDbContext(DbContextOptions<AppDbContext> options) 
    : IdentityDbContext<User, UserRole, Guid>(options)
{
    public DbSet<ShortUrl> ShortUrls { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Remove "AspNet" prefix from Identity table names
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName != null && tableName.StartsWith("AspNet")) 
                entityType.SetTableName(tableName.Substring(6));
        }
    }
}