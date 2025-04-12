using MediatR;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Infrastructure.Services.Interfaces;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Api.Application.Features.Auth.Commands.Logout;

public record LogoutCommand : IRequest<LogoutResponse>;

public class LogoutResponse : BaseResponse
{
}

public class LogoutCommandHandler : AuthRequiredHandler, IRequestHandler<LogoutCommand, LogoutResponse>
{
    private readonly ICookieService _cookieService;
    private readonly ISessionService _sessionService;

    public LogoutCommandHandler(ICookieService cookieService, ISessionService sessionService,
        ITokenService tokenService,
        IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        _cookieService = cookieService;
        _sessionService = sessionService;
    }

    public async Task<LogoutResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();
        if (userId == null)
            throw new UnauthorizedException("User is not logged in");

        var refreshToken = _cookieService.Get(CookieConsts.RefreshToken);
        var sessionId = _cookieService.Get(CookieConsts.SessionId);

        if (string.IsNullOrEmpty(refreshToken) || string.IsNullOrEmpty(sessionId))
        {
            return new LogoutResponse { Message = "User is not logged in on this device." };
        }

        var session = await _sessionService.GetSessionByRefreshTokenAsync(refreshToken);

        if (session == null || session.RefreshToken != refreshToken)
        {
            return new LogoutResponse { Message = "Session has expired or is already invalidated." };
        }

        await _sessionService.InvalidateSessionAsync(session);

        _cookieService.Delete(CookieConsts.RefreshToken);
        _cookieService.Delete(CookieConsts.SessionId);

        return new LogoutResponse { Message = "Logged out successfully from this device." };
    }
}