using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Infrastructure.Services.Interfaces;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Api.Application.Features.Auth.Commands.RefreshTokens;


public record RefreshTokensCommand : IRequest<RefreshTokensResponse>;

public class RefreshTokensResponse : BaseResponse
{
    public string AccessToken { get; set; } = string.Empty;
}

public class RefreshTokensCommandHandler
    : IRequestHandler<RefreshTokensCommand, RefreshTokensResponse>
{
    private readonly ICookieService _cookieService;
    private readonly ISessionService _sessionService;
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;

    public RefreshTokensCommandHandler(ICookieService cookieService, ISessionService sessionService,
        UserManager<AppUser> userManager, ITokenService tokenService)
    {
        _cookieService = cookieService;
        _sessionService = sessionService;
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<RefreshTokensResponse> Handle(RefreshTokensCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = _cookieService.Get(CookieConsts.RefreshToken);
        if (string.IsNullOrEmpty(refreshToken))
            throw new NotFoundException("Refresh token not found in cookies.");

        var session = await _sessionService.GetSessionByRefreshTokenAsync(refreshToken);
        if (session == null)
            throw new NotFoundException("Session not found for the provided refresh token.");

        var user = await _userManager.FindByIdAsync(session.UserId);
        if (user == null)
            throw new NotFoundException("User not found for the session.");

        var newAccessToken = _tokenService.GenerateAccessToken(user);
        var newRefreshToken = _tokenService.GenerateRefreshToken();

        await _sessionService.InvalidateSessionAsync(session);
        await _sessionService.CreateSessionAsync(user.Id, newRefreshToken);

        _cookieService.Append(CookieConsts.RefreshToken, newRefreshToken.Token, true, newRefreshToken.ExpiryDate);

        return new RefreshTokensResponse
        {
            Message = "Tokens refreshed successfully.",
            AccessToken = newAccessToken
        };
    }
}