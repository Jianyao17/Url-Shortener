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
        
        // User - ShortUrl relationship
        builder.Entity<User>()
            .HasMany(u => u.ShortUrls)
            .WithOne(su => su.User)
            .HasForeignKey(su => su.UserId);
        
        // User - ShortUrlChange relationship
        builder.Entity<User>()
            .HasMany(u => u.ShortUrlChanges)
            .WithOne(suc => suc.User)
            .HasForeignKey(suc => suc.UserId);
        
        // ShortUrl - ShortUrlChange relationship
        builder.Entity<ShortUrl>()
            .HasMany(su => su.Changes)
            .WithOne(suc => suc.ShortUrl)
            .HasForeignKey(suc => suc.ShortUrlId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // ShortUrl - ShortUrlClick relationship
        builder.Entity<ShortUrl>()
            .HasMany(su => su.Clicks)
            .WithOne(suc => suc.ShortUrl)
            .HasForeignKey(suc => suc.ShortUrlId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Global query filters & index for soft deletion
        builder.Entity<ShortUrl>()
            .HasQueryFilter(x => x.DeletedAt == null)
            .HasIndex(x => x.DeletedAt)
            .HasFilter("DeletedAt IS NULL");
        
        builder.Entity<ShortUrlChange>()
            .HasQueryFilter(x => x.DeletedAt == null)
            .HasIndex(x => x.DeletedAt)
            .HasFilter("DeletedAt IS NULL");
        
        builder.Entity<ShortUrlClick>()
            .HasQueryFilter(x => x.DeletedAt == null)
            .HasIndex(x => x.DeletedAt)
            .HasFilter("DeletedAt IS NULL");
    }
}