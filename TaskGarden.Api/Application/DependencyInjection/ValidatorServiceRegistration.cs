using FluentValidation;
using TaskGarden.Api.Application.Features.Auth.Commands.ChangePassword;
using TaskGarden.Api.Application.Features.Auth.Commands.ForgotPassword;
using TaskGarden.Api.Application.Features.Auth.Commands.Google;
using TaskGarden.Api.Application.Features.Auth.Commands.Login;
using TaskGarden.Api.Application.Features.Auth.Commands.Register;
using TaskGarden.Api.Application.Features.Categories.Commands.CreateCategory;
using TaskGarden.Api.Application.Features.Categories.Commands.UpdateCategory;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using TaskGarden.Api.Application.Features.TaskList.Commands.CreateTaskList;
using TaskGarden.Api.Application.Features.TaskList.Commands.DeleteTaskList;
using TaskGarden.Api.Application.Features.TaskList.Commands.UpdateTaskList;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItemCompletedStatus;
using TaskGarden.Application.Features.Categories.Commands.DeleteCategory;
using TaskGarden.Application.Features.TaskListItem.Commands.UpdateTaskListItem;


namespace TaskGarden.Api.Application.DependencyInjection;

public static class ValidatorServiceRegistration
{
    public static IServiceCollection AddValidatorService(this IServiceCollection services)
    {
        // Auth Validators
        services.AddValidatorsFromAssemblyContaining<ForgotPasswordCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<ChangePasswordCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<GoogleLoginCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<LoginCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<RegisterCommandValidator>();

        // Category Validators
        services.AddValidatorsFromAssemblyContaining<CreateCategoryCommand>();
        services.AddValidatorsFromAssemblyContaining<UpdateCategoryCommand>();
        services.AddValidatorsFromAssemblyContaining<DeleteCategoryCommand>();

        // Task List Validators
        services.AddValidatorsFromAssemblyContaining<GetAllTaskListsForCategoryQueryValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateTaskListCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateTaskListCommandValidator>();
        // Remove these if no validation required
        services.AddValidatorsFromAssemblyContaining<DeleteTaskListCommandHandler>();

        // Task List Item Validators
        services.AddValidatorsFromAssemblyContaining<CreateTaskListItemCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateTaskListItemCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<DeleteTaskListCommandHandler>();
        services.AddValidatorsFromAssemblyContaining<UpdateTaskListItemCompletedStatusCommand>();

        return services;
    }
}