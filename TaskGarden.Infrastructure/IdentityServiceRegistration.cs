using Microsoft.Extensions.DependencyInjection;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Infrastructure.Services.Identity;

namespace TaskGarden.Infrastructure;

public static class IdentityServiceRegistration
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services)
    {
        services.AddScoped<ICookieService, CookieService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ISessionService, SessionService>();
        services.AddScoped<IGoogleAuthService, GoogleAuthService>();


        return services;
    }
}