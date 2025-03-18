using MediatR;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Infrastructure.Services.Interfaces;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
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

        var session = await _sessionService.GetSessionByRefreshTokenAsync(refreshToken);

        if (session == null)
            throw new NotFoundException("Session not found");

        await _sessionService.InvalidateSessionAsync(session);

        _cookieService.Delete(CookieConsts.RefreshToken);

        return new LogoutResponse { Message = "Logged out successfully." };
    }
}