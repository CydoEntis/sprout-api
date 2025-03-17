﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Domain.Enums;
using Newtonsoft.Json;
using TaskGarden.Application.Common;
using TaskGarden.Infrastructure.Projections;

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

    public string? ExtractTokenFromAuthorizationHeader(string authorizationHeader)
    {
        return authorizationHeader?.StartsWith("Bearer ") == true
            ? authorizationHeader.Substring(7)
            : authorizationHeader;
    }

    public string? ExtractUserIdFromToken(string token)
    {
        var jwtHandler = new JwtSecurityTokenHandler();
        var jwtToken = jwtHandler.ReadJwtToken(token);
        return jwtToken?.Claims?.FirstOrDefault(c => c.Type == "userId")?.Value;
    }

    // New method for generating invite token
    public string GenerateInviteToken(AppUser inviter, TaskListPreview taskList)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("inviter", $"{inviter.FirstName} {inviter.LastName}"),
            new Claim("inviterEmail", inviter.Email),
            new Claim("taskListName", taskList.Name),
            new Claim("taskListId", taskList.Id.ToString()),
            new Claim("category", taskList.CategoryName),
            new Claim("inviteDate", DateTime.UtcNow.ToString("MM/dd/yyyy"))
        };

        var memberNames = taskList.Members.Select(m => m.Name).ToList();
        var membersJson = JsonConvert.SerializeObject(memberNames);
        claims.Add(new Claim("members", membersJson));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}