using MediatR;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.Auth.Commands.Logout;

public record LogoutCommand : IRequest<LogoutResponse>;

public class LogoutResponse : BaseResponse;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutResponse>
{
    private readonly IUserContextService _userContextService;
    private readonly ICookieService _cookieService;
    private readonly ISessionService _sessionService;

    public LogoutCommandHandler(ICookieService cookieService, ISessionService sessionService,
        IUserContextService userContextService)
    {
        _cookieService = cookieService;
        _sessionService = sessionService;
        _userContextService = userContextService;
    }

    public async Task<LogoutResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var userId = _userContextService.GetUserId();
        if (userId == null) throw new NotFoundException("User is not logged in");

        var session = await _sessionService.GetSessionByUserIdAsync(userId);
        if (session != null)
            await _sessionService.InvalidateSessionAsync(session);

        _cookieService.Delete(CookieConsts.RefreshToken);
        return new LogoutResponse { Message = "Logged out successfully." };
    }
}