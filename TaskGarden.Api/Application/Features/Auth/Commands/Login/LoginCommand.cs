using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Api.Application.Features.Demo;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Api.Infrastructure.Services.Interfaces;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Api.Application.Features.Auth.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;

public class LoginResponse : BaseResponse
{
    public string AccessToken { get; init; } = string.Empty;
}

public class LoginCommandHandler
    : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly ISessionService _sessionService;
    private readonly ICookieService _cookieService;
    private readonly IValidator<LoginCommand> _validator;
    private const string DemoEmail = "demo1@demo.com";

    private readonly string[] _demoUserIds =
    {
        "1b503418-dc0f-4187-93c0-2e30070b2835", // Demo User 1
        "9e22a16c-da04-4232-b479-95c3a7b89259", // Demo User 2
        "40fcec36-7eef-42d8-8086-cd2226b88d00" // Demo User 3
    };

    public LoginCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService,
        ISessionService sessionService, ICookieService cookieService, IValidator<LoginCommand> validator, AppDbContext context)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _sessionService = sessionService;
        _cookieService = cookieService;
        _validator = validator;
        _context = context;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            throw new NotFoundException("User not found");

        var accessToken = await GenerateAndStoreTokensAsync(user);

        if (_demoUserIds.Contains(user.Id))
        {
            await SeedDataManager.ClearAndReseedDatabase(_context);
        }

        return new LoginResponse { Message = "Logged in successfully", AccessToken = accessToken };
    }

    private async Task<string> GenerateAndStoreTokensAsync(AppUser user)
    {
        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        var session = await _sessionService.CreateSessionAsync(user.Id, refreshToken);

        _cookieService.Append(CookieConsts.RefreshToken, refreshToken.Token, httpOnly: true, refreshToken.ExpiryDate);
        _cookieService.Append(CookieConsts.SessionId, session.SessionId, httpOnly: true, refreshToken.ExpiryDate);

        return accessToken;
    }
}