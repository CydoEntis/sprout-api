using Sprout.Api.Infrastructure.Services.Identity;
using Sprout.Api.Infrastructure.Services.Interfaces;
using Sprout.Application.Services.Contracts;
using Sprout.Infrastructure.Services.Identity;

namespace Sprout.Api.Infrastructure.DependencyInjection;

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