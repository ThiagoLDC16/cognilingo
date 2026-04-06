using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Cognilingo.Application.Identity.Interfaces;
using Cognilingo.Infrastructure.Identity.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cognilingo.Infrastructure.Identity.Authentication;

public sealed class JwtTokenService(
    IOptions<JwtAuthOptions> options
) : ITokenService
{
    private const int DefaultExpirationInHours = 1;

    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecurityKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: options.Value.Issuer,
            audience: options.Value.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddHours(DefaultExpirationInHours),
            signingCredentials: creds
        );

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        return jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
    }

    public string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }
}