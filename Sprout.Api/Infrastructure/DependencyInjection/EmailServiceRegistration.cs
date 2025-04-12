using TaskGarden.Api.Infrastructure.Services.Email;
using TaskGarden.Api.Infrastructure.Services.Interfaces;


namespace TaskGarden.Api.Infrastructure.DependencyInjection;

public static class EmailServiceRegistration
{
    public static IServiceCollection AddEmailService(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, MailKitService>();
        services.AddScoped<IEmailTemplateService, EmailTemplateService>();

        return services;
    }
}