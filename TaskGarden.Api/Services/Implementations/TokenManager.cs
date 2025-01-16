using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TaskGarden.Api.Constants;
using TaskGarden.Data.Models;

namespace TaskGarden.Api.Services.Implementations;

public class TokenManager
{
    private readonly IConfiguration _configuration;
    private readonly string _jwtSecret;
    private readonly string _jwtAudience;
    private readonly string _jwtIssuer;

    public TokenManager(IConfiguration configuration)
    {
        _configuration = configuration;
        _jwtSecret = configuration[JwtConsts.Secret];
        _jwtAudience = configuration[JwtConsts.Audience];
        _jwtIssuer = configuration[JwtConsts.Issuer];
    }

    public string GenerateAccessToken(AppUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("userId", user.Id)
        };

        var token = new JwtSecurityToken(
            issuer: _jwtIssuer,
            audience: _jwtAudience,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    // TODO: Add Logic to create Refresh Tokens.
    public RefreshToken GenerateRefreshToken()
    {
        var expirationDate = DateTime.Now.AddHours(16);
        var token = Guid.NewGuid().ToString();

        return new RefreshToken() { Token = token, ExpiryDate = expirationDate };
    }
}