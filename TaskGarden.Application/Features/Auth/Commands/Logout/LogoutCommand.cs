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
    private readonly ICookieService _cookieService;
    private readonly ISessionService _sessionService;

    public LogoutCommandHandler(ICookieService cookieService, ISessionService sessionService)
    {
        _cookieService = cookieService;
        _sessionService = sessionService;
    }

    public async Task<LogoutResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = _cookieService.Get(CookieConsts.RefreshToken);
        if (string.IsNullOrEmpty(refreshToken))
            throw new NotFoundException("Token not found");

        var session = await _sessionService.GetSessionAsync(refreshToken);
        await _sessionService.InvalidateSessionAsync(session);

        _cookieService.Delete(CookieConsts.RefreshToken);
        return new LogoutResponse { Message = "Logged out successfully." };
    }
}