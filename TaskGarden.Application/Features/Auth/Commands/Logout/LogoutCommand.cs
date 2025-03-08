using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    private readonly IHttpContextAccessor _httpContextAccessor; // Declare IHttpContextAccessor

    // Inject IHttpContextAccessor in constructor
    public LogoutCommandHandler(ICookieService cookieService, ISessionService sessionService,
        IUserContextService userContextService, IHttpContextAccessor httpContextAccessor)
    {
        _cookieService = cookieService;
        _sessionService = sessionService;
        _userContextService = userContextService;
        _httpContextAccessor = httpContextAccessor; // Initialize it
    }


    public async Task<LogoutResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var authorizationHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
        var token = authorizationHeader.StartsWith("Bearer ") ? authorizationHeader.Substring(7) : authorizationHeader;

        try
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);

            var userId = jwtToken?.Claims?.FirstOrDefault(c => c.Type == "userId")?.Value;

            if (userId == null)
            {
                throw new NotFoundException("User is not logged in");
            }


            await _sessionService.InvalidateAllSessionsByUserIdAsync(userId);

            _cookieService.Delete(CookieConsts.RefreshToken);
            return new LogoutResponse { Message = "Logged out successfully." };
        }
        catch (Exception ex)
        {
            throw new NotFoundException("Invalid or expired token");
        }
    }
}