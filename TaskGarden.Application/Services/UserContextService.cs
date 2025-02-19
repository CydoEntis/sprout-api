using Microsoft.AspNetCore.Http;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Services;

public class UserContextService : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetUserId()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null || !(user.Identity?.IsAuthenticated ?? false))
        {
            return null;
        }

        return user.FindFirst("userId")?.Value;
    }
}