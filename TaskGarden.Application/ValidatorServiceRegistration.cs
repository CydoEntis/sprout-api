using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TaskGarden.Application.Features.Auth.Commands.Login;
using TaskGarden.Application.Features.Auth.Commands.Register;

namespace TaskGarden.Application;

public static class ValidatorServiceRegistration
{
    public static IServiceCollection AddValidatorService(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<RegisterCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<LoginCommandValidator>();


        return services;
    }
}