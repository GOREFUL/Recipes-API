using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Recipes.Domain.Abstractions;
using Recipes.Domain.Entities.UserContext;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Recipes.Infrastructure.Auth;
public class JwtTokenService(ILogger<JwtTokenService> logger,
    UserManager<ApplicationUser> users, IOptions<JwtOptions> opt) : IJwtTokenService
{
    public async Task<(string token, DateTime expires)> CreateAsync(ApplicationUser user, CancellationToken ct = default)
    {
        logger.LogInformation("Creating JWT token for user {UserId}", user.Id);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(opt.Value.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var roles = await users.GetRolesAsync(user);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.DisplayName ?? user.UserName ?? user.Email ?? user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty)
        };
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var now = DateTime.UtcNow;
        var expires = now.AddMinutes(opt.Value.AccessTokenExpirationMinutes);

        var jwt = new JwtSecurityToken(
            issuer: opt.Value.Issuer,
            audience: opt.Value.Audience,
            claims: claims,
            notBefore: now,
            expires: expires,
            signingCredentials: creds);

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);
        logger.LogInformation("JWT token created for user {UserId}, expires at {Expires}", user.Id, expires);
        return (token, expires);
    }
}
