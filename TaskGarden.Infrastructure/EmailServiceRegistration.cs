using Microsoft.Extensions.DependencyInjection;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Infrastructure.Services.Email;

namespace TaskGarden.Infrastructure;

public static class EmailServiceRegistration
{
    public static IServiceCollection AddEmailService(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, MailKitService>();
        services.AddScoped<IEmailTemplateService, EmailTemplateService>();

        return services;
    }
}