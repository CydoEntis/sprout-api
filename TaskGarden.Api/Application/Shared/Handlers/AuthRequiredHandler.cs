using TaskGarden.Application.Common.Exceptions;

namespace TaskGarden.Api.Application.Shared.Handlers;

public abstract class AuthRequiredHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    protected AuthRequiredHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected string GetAuthenticatedUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.Items["UserId"]?.ToString();

        if (string.IsNullOrEmpty(userId))
            throw new UnauthorizedException("User ID is missing from the token.");

        return userId;
    }
}