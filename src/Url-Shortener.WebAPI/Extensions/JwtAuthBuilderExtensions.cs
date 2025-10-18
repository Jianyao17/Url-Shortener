using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using UrlShortener.WebAPI.Config;

namespace UrlShortener.WebAPI.Extensions;

internal static class JwtAuthBuilderExtensions
{
    internal static void AddJwtAuthentication(this IServiceCollection services)
    {
        var config = services.BuildServiceProvider().GetRequiredService<JwtConfig>();
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey));

        services.AddAuthorization();
        services.
            AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = 
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true, ValidateAudience = true,
                        ValidateLifetime = true, ValidateIssuerSigningKey = true,
                        ValidIssuer = config.Issuer, ValidAudience = config.Audience,
                        IssuerSigningKey = signingKey,
                        RequireExpirationTime = true,
                    };
            });
    }
}