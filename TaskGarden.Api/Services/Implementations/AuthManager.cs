using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TaskGarden.Api.Constants;
using TaskGarden.Api.Dtos;
using TaskGarden.Api.Dtos.Auth;
using TaskGarden.Api.Errors;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Models;

namespace TaskGarden.Api.Services.Implementations;

public class AuthManager : IAuthManager
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ICookieManager _cookieManager;
    private readonly ISessionManager _sessionManager;
    private readonly ITokenManager _tokenManager;
    private readonly IMapper _mapper;

    private AppUser? _user;

    public AuthManager(UserManager<AppUser> userManager,
        IMapper mapper, ITokenManager tokenManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _tokenManager = tokenManager;
    }

    public async Task<AuthenticatedResponseDto> Login(LoginRequestDto loginDto)
    {
        _user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (_user == null)
            throw new ValidationException("email", ExceptionMessages.InvalidCredentials);

        if (!await _userManager.CheckPasswordAsync(_user, loginDto.Password))
            throw new ValidationException("email", ExceptionMessages.InvalidCredentials);

        var accessToken = _tokenManager.GenerateAccessToken(_user);
        var refreshToken = _tokenManager.GenerateRefreshToken();
        await _sessionManager.CreateSessionAsync(_user.Id, refreshToken);
        _cookieManager.Append(CookieConsts.RefreshToken, refreshToken.Token, true, refreshToken.ExpiryDate);

        return new AuthenticatedResponseDto() { Message = "Logged in successfully.", AccessToken = accessToken };
    }

    public async Task<AuthenticatedResponseDto> Register(RegisterRequestDto registerDto)
    {
        var existingEmail = await _userManager.FindByEmailAsync(registerDto.Email);
        if (existingEmail is not null)
            throw new ValidationException("email", ExceptionMessages.EmailInUse);

        var _user = _mapper.Map<AppUser>(registerDto);
        var result = await _userManager.CreateAsync(_user, registerDto.Password);

        if (!result.Succeeded)
                throw new ResourceCreationException(ExceptionMessages.RegistrationFailed);

        return null;
    }


    public async Task<RefreshTokensResponseDto> RefreshTokens()
    {
        var refreshToken = _cookieManager.Get(CookieConsts.RefreshToken);
        if (string.IsNullOrEmpty(refreshToken))
            throw new NotFoundException(ExceptionMessages.TokenNotFound);

        var session = await _sessionManager.GetSessionAsync(refreshToken);
        if (session is null)
            throw new NotFoundException(ExceptionMessages.SessionNotFound);

        var _user = await _userManager.FindByIdAsync(session.UserId);
        if (_user is null)
            throw new NotFoundException(ExceptionMessages.UserNotFound);

        var newAccessToken = _tokenManager.GenerateAccessToken(_user);
        var newRefreshToken = _tokenManager.GenerateRefreshToken();

        await _sessionManager.InvalidateSessionAsync(session);
        await _sessionManager.CreateSessionAsync(newAccessToken, newRefreshToken);

        _cookieManager.Append(CookieConsts.RefreshToken, newRefreshToken.Token, true, newRefreshToken.ExpiryDate);

        return new RefreshTokensResponseDto()
            { Message = "Tokens refreshed successfully.", AccessToken = newAccessToken };
    }

    public async Task<LogoutResponseDto> Logout()
    {
        var refreshToken = _cookieManager.Get(CookieConsts.RefreshToken);
        if (string.IsNullOrEmpty(refreshToken))
            throw new NotFoundException(ExceptionMessages.TokenNotFound);

        var session = await _sessionManager.GetSessionAsync(refreshToken);
        if (session is null)
            throw new NotFoundException(ExceptionMessages.SessionNotFound);

        await _sessionManager.InvalidateSessionAsync(session);
        _cookieManager.Delete(CookieConsts.RefreshToken);
        return new LogoutResponseDto() { Message = "Logged out successfully." };
    }


    private async Task<RefreshToken> GenerateRefreshToken()
    {
        var expires = DateTime.Now.AddHours(16);
        var token = Guid.NewGuid().ToString();

        return new RefreshToken { Token = token, ExpiryDate = expires };
    }
}