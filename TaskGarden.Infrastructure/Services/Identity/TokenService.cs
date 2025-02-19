using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaskGarden.Application.Common;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Repositories.Contracts;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly ISessionRepository _sessionRepository;
    private readonly string _jwtSecret;
    private readonly string _jwtAudience;
    private readonly string _jwtIssuer;

    public TokenService(IConfiguration configuration, ISessionRepository sessionRepository)
    {
        _configuration = configuration;
        _sessionRepository = sessionRepository;
        _jwtSecret = _configuration[JwtConsts.Secret];
        _jwtAudience = _configuration[JwtConsts.Audience];
        _jwtIssuer = _configuration[JwtConsts.Issuer];
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
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public RefreshToken GenerateRefreshToken()
    {
        var expirationDate = DateTime.UtcNow.AddHours(16);
        var token = Guid.NewGuid().ToString();

        return new RefreshToken() { Token = token, ExpiryDate = expirationDate };
    }

    public async Task<bool> IsRefreshTokenValid(string token)
    {
        var session = await _sessionRepository.GetByRefreshToken(token);
        return session.RefreshTokenExpirationDate > DateTime.UtcNow;
    }
}