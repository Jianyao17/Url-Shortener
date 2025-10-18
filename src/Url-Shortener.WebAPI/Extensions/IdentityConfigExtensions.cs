using Microsoft.AspNetCore.Identity;
using UrlShortener.WebAPI.Config;

namespace UrlShortener.WebAPI.Extensions;

internal static class IdentityConfigExtensions
{
    internal static Action<IdentityOptions> LoadIdentityConfig(this IHostApplicationBuilder builder)
    {
        var identityConfig = builder.Configuration
            .GetValue<IdentityConfig>("Identity") ?? new IdentityConfig();
        return options =>
        {
            options.User = identityConfig.User;
            options.Password = identityConfig.Password;
            options.ClaimsIdentity = identityConfig.ClaimsIdentity;
            options.Lockout = identityConfig.Lockout;
            options.SignIn = identityConfig.SignIn;
            options.Tokens = identityConfig.Tokens;
            options.Stores = identityConfig.Stores;
        };
    }
}