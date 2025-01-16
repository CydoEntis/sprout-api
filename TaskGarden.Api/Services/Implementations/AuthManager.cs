using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TaskGarden.Api.Constants;
using TaskGarden.Api.Dtos.Auth;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data;
using TaskGarden.Data.Models;

namespace TaskGarden.Api.Services.Implementations;

public class AuthManager : IAuthManager
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly string _jwtSecret;
    private readonly string _jwtAudience;
    private readonly string _jwtIssuer;

    private AppUser? _user;

    public AuthManager(AppDbContext context, UserManager<AppUser> userManager, IConfiguration configuration,
        IMapper mapper)
    {
        _context = context;
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

    public async Task<IEnumerable<IdentityError>?> Register(RegisterRequestDto registerDto)
    {
        var _user = _mapper.Map<AppUser>(registerDto);
        var result = await _userManager.CreateAsync(_user, registerDto.Password);

        if (!result.Succeeded)
        {
            return result.Errors;
        }

        return null;
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

    private async Task CreateSessionAsync(string userId, RefreshToken refreshToken)
    {
        var sessionId = Guid.NewGuid();
        var session = new Session
        {
            UserId = userId,
            SessionId = sessionId,
            RefreshToken = refreshToken.Token,
            RefreshTokenExpirationDate = refreshToken.ExpiryDate,
        };
    }

    private async Task<Session> GetSessionByUserIdAsync(string userId)
    {
        return await _context.Session.GetByUserIdAsync(userId);
    }

    private Task<bool> ValidateRefreshToken(string refreshToken)
    {
        var session = await _context.Session.GetByRefreshTokenAsync(refreshToken);
        return session != null && session.RefreshTokenExpirationDate > DateTime.Now;
    }
}