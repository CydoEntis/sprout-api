using Sprout.Api.Infrastructure.Services.Email;
using Sprout.Api.Infrastructure.Services.Interfaces;


namespace Sprout.Api.Infrastructure.DependencyInjection;

public static class EmailServiceRegistration
{
    public static IServiceCollection AddEmailService(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, MailKitService>();
        services.AddScoped<IEmailTemplateService, EmailTemplateService>();

        return services;
    }
}