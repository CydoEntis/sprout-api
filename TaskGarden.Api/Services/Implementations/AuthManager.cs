using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TaskGarden.Api.Dtos.Auth;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Models;

namespace TaskGarden.Api.Services.Implementations;

public class AuthManager : IAuthManager
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private User? _user;

    public AuthManager(UserManager<User> userManager, IConfiguration configuration, IMapper mapper)
    {
        _userManager = userManager;
        _configuration = configuration;
        _mapper = mapper;
    }

    public Task<LoginResponseDto> Login(LoginRequestDto loginDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<IdentityError>> Register(RegisterRequestDto registerDto)
    {
        throw new NotImplementedException();
    }

    public Task RefreshTokens()
    {
        throw new NotImplementedException();
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }

    private async Task<string> GenerateAccessToken()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, _user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, _user.Email),
            new Claim("userId", _user.Id),
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}