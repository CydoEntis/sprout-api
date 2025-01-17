﻿using System.IdentityModel.Tokens.Jwt;
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
    private readonly UserManager<AppUser> _userManager;
    private readonly ICookieManager _cookieManager;
    private readonly ISessionManager _sessionManager;
    private readonly ITokenManager _tokenManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    private AppUser? _user;

    public AuthManager(UserManager<AppUser> userManager, IConfiguration configuration,
        IMapper mapper, ITokenManager tokenManager)
    {
        _userManager = userManager;
        _configuration = configuration;
        _mapper = mapper;
        _tokenManager = tokenManager;
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto loginDto)
    {
        _user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (_user == null) throw new ArgumentNullException("User not found.");

        bool isValidCredentials = await _userManager.CheckPasswordAsync(_user, loginDto.Password);
        if (!isValidCredentials) throw new ArgumentException("Invalid credentials.");

        var token = _tokenManager.GenerateToken(_user);

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
            return result.Errors;

        return null;
    }


    public Task RefreshTokens()
    {
        throw new NotImplementedException();
    }

    public Task Logout()
    {
        var refreshToken = _cookieManager.Get()
    }

    


    private async Task<RefreshToken> GenerateRefreshToken()
    {
        var expires = DateTime.Now.AddHours(16);
        var token = Guid.NewGuid().ToString();

        return new RefreshToken { Token = token, ExpiryDate = expires };
    }
}