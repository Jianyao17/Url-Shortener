using Microsoft.AspNetCore.Identity;

namespace UrlShortener.WebAPI.Config;

internal sealed class IdentityConfig : IdentityOptions
{
    public IdentityConfig()
    {
        Password.RequireDigit = true;
        Password.RequireLowercase = true;
        Password.RequireUppercase = true;
        Password.RequireNonAlphanumeric = false;
        Password.RequiredUniqueChars = 0;
        Password.RequiredLength = 8;
        User.RequireUniqueEmail = true;
    }
}