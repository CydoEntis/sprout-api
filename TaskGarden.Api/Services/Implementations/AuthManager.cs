using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TaskGarden.Api.Constants;
using TaskGarden.Api.Dtos.Auth;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Models;

namespace TaskGarden.Api.Services.Implementations;

public class AuthManager : IAuthManager
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly string _jwtSecret;
    private readonly string _jwtAudience;
    private readonly string _jwtIssuer;

    private User? _user;

    public AuthManager(UserManager<User> userManager, IConfiguration configuration, IMapper mapper)
    {
        _userManager = userManager;
        _configuration = configuration;
        _mapper = mapper;

        _jwtSecret = configuration[JwtConsts.Secret];
        _jwtAudience = configuration[JwtConsts.Audience];
        _jwtIssuer = configuration[JwtConsts.Issuer];
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto loginDto)
    {
        _user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (_user == null) throw new ArgumentNullException("User not found.");

        bool isValidCredentials = await _userManager.CheckPasswordAsync(_user, loginDto.Password);
        if (!isValidCredentials) throw new ArgumentException("Invalid credentials.");

        var token = GenerateAccessToken();

        return new LoginResponseDto
        {
            Token = token,
            UserId = _user.Id,
        };
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

    private string GenerateAccessToken()
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
            issuer: _jwtIssuer,
            audience: _jwtAudience,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


    private async Task<RefreshToken> GenerateRefreshToken()
    {
        var expires = DateTime.Now.AddHours(16);
        var token = Guid.NewGuid().ToString();

        return new RefreshToken { Token = token, ExpiryDate = expires };
    }
}