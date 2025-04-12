using TaskGarden.Api.Infrastructure.Services.Identity;
using TaskGarden.Api.Infrastructure.Services.Interfaces;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Infrastructure.Services.Identity;

namespace TaskGarden.Api.Infrastructure.DependencyInjection;

public static class IdentityServiceRegistration
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services)
    {
        // services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICookieService, CookieService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ISessionService, SessionService>();

        return services;
    }
}