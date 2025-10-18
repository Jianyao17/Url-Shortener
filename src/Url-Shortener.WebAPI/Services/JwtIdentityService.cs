using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using UrlShortener.WebAPI.Config;
using UrlShortener.WebAPI.Entities;

namespace UrlShortener.WebAPI.Services;

internal sealed class JwtIdentityService(JwtConfig config)
{
    /// <summary>
    /// Generates a JWT token for the specified user.
    /// </summary>
    public string GenerateJwtToken(User user)
    {
        // Define JWT claims which include user identity information
        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new (JwtRegisteredClaimNames.PreferredUsername, user.UserName!),
            new (JwtRegisteredClaimNames.Email, user.Email!),
        };
        
        // Create signing credentials using the secret key from configuration
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddMinutes(config.ExpirationInMinutes);
        
        // Create the JWT token
        var token = new JwtSecurityToken(
            issuer: config.Issuer, audience: config.Audience,
            claims: claims, expires: expiration,
            signingCredentials: creds, 
            notBefore: DateTime.UtcNow);
        
        // Return the serialized JWT token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}