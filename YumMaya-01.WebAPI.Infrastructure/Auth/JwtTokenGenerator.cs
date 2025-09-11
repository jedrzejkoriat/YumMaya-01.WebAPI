using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using YumMaya_01.WebAPI.Application.Contracts.Auth;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Infrastructure.Auth;

public sealed class JwtTokenGenerator : ITokenGenerator
{
    private readonly string _jwtSecret;
    private readonly string _jwtIssuer;
    private readonly string _jwtAudience;

    public JwtTokenGenerator(IConfiguration config)
    {
        _jwtSecret = config["Jwt:Secret"] ?? throw new ArgumentNullException("JWT Secret is not configured.");
        _jwtIssuer = config["Jwt:Issuer"] ?? throw new ArgumentNullException("JWT Issuer is not configured.");
        _jwtAudience = config["Jwt:Audience"] ?? throw new ArgumentNullException("JWT Audience is not configured.");
    }

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtIssuer,
            audience: _jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(10),
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}