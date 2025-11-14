using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UrlShortener.WebAPI.Entities;

namespace UrlShortener.WebAPI.Database;

internal class AppDbContext(DbContextOptions<AppDbContext> options) 
    : IdentityDbContext<User, UserRole, Guid>(options)
{
    public DbSet<ShortUrl> ShortUrls { get; set; }
    public DbSet<ShortUrlChange> ShortUrlChanges { get; set; }
    public DbSet<ShortUrlClick> ShortUrlClicks { get; set; }
    
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
        
        // Indexes for soft delete filtering
        builder.Entity<ShortUrl>()
            .HasIndex(x => x.DeletedAt)
            .HasFilter("\"DeletedAt\" IS NULL");
        
        builder.Entity<ShortUrlChange>()
            .HasIndex(x => x.DeletedAt)
            .HasFilter("\"DeletedAt\" IS NULL");
        
        builder.Entity<ShortUrlClick>()
            .HasIndex(x => x.DeletedAt)
            .HasFilter("\"DeletedAt\" IS NULL");
        
        
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
        
        
        // Global query filters for soft delete
        builder.Entity<ShortUrl>().HasQueryFilter(e => e.DeletedAt == null);
        builder.Entity<ShortUrlChange>().HasQueryFilter(e => e.DeletedAt == null);
        builder.Entity<ShortUrlClick>().HasQueryFilter(e => e.DeletedAt == null);
    }
}