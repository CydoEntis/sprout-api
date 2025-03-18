using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Api.Infrastructure.Services.Interfaces;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Api.Application.Features.Auth.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;

public class LoginResponse : BaseResponse
{
    public string AccessToken { get; init; } = string.Empty;
}

public class LoginCommandHandler
    : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly ISessionService _sessionService;
    private readonly ICookieService _cookieService;
    private readonly IValidator<LoginCommand> _validator;

    public LoginCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService,
        ISessionService sessionService, ICookieService cookieService, IValidator<LoginCommand> validator)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _sessionService = sessionService;
        _cookieService = cookieService;
        _validator = validator;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            throw new NotFoundException("User not found");

        var accessToken = GenerateAndStoreTokensAsync(user).ToString();

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