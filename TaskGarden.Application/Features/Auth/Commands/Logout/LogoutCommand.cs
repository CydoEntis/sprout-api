using MediatR;
using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.Auth.Commands.Logout
{
    public record LogoutCommand : IRequest<LogoutResponse>;

    public class LogoutResponse : BaseResponse
    {
    }

    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutResponse>
    {
        private readonly IUserContextService _userContextService;
        private readonly ICookieService _cookieService;
        private readonly ISessionService _sessionService;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogoutCommandHandler(ICookieService cookieService, ISessionService sessionService,
            IUserContextService userContextService, ITokenService tokenService,
            IHttpContextAccessor httpContextAccessor)
        {
            _cookieService = cookieService;
            _sessionService = sessionService;
            _userContextService = userContextService;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<LogoutResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var authorizationHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            var token = _tokenService.ExtractTokenFromAuthorizationHeader(authorizationHeader);

            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedException("User is not logged in");

            var userId = _tokenService.ExtractUserIdFromToken(token);

            if (userId == null)
                throw new UnauthorizedException("User is not logged in");

            var session = await _sessionService.GetSessionByRefreshTokenAsync(token);

            if (session == null)
                throw new NotFoundException("Session not found");

            await _sessionService.InvalidateSessionAsync(session);

            _cookieService.Delete(CookieConsts.RefreshToken);

            return new LogoutResponse { Message = "Logged out successfully." };
        }
    }
}