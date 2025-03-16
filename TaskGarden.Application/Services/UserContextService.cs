using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Services;

public class UserContextService : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetAuthenticatedUserId()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user?.Identity?.IsAuthenticated != true)
            throw new UnauthorizedException("User is not authenticated.");

        return user.FindFirst("userId")?.Value
               ?? throw new UnauthorizedException("User ID is missing from the token.");
    }
}