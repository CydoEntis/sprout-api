using MediatR;
using TaskGarden.Api.Constants;
using TaskGarden.Application.Exceptions;
using TaskGarden.Application.Features.Auth.Commands.Login;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.Auth.Commands.Logout;

public record LogoutCommand : IRequest<LogoutResponse>;

public class LogoutResponse : BaseResponse;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutResponse>
{
    private readonly ICookieManager _cookieManager;
    private readonly ISessionManager _sessionManager;

    public LogoutCommandHandler(ICookieManager cookieManager, ISessionManager sessionManager)
    {
        _cookieManager = cookieManager;
        _sessionManager = sessionManager;
    }

    public async Task<LogoutResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = _cookieManager.Get(CookieConsts.RefreshToken);
        if (string.IsNullOrEmpty(refreshToken))
            throw new NotFoundException("Token not found");

        var session = await _sessionManager.GetSessionAsync(refreshToken);
        await _sessionManager.InvalidateSessionAsync(session);

        _cookieManager.Delete(CookieConsts.RefreshToken);
        return new LogoutResponse { Message = "Logged out successfully." };
    }
}