using Microsoft.EntityFrameworkCore;
using UrlShortener.WebAPI.Models;

namespace UrlShortener.WebAPI.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : DbContext(options)
{
    public DbSet<ShortUrl> ShortUrls { get; set; }
}