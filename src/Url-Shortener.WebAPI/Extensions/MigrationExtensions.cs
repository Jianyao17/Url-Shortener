using Microsoft.EntityFrameworkCore;
using UrlShortener.WebAPI.Database;

namespace UrlShortener.WebAPI.Extensions;

internal static class MigrationExtensions
{
    internal static void ExecuteMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }
}