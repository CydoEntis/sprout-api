using FluentValidation;
using Sprout.Api.Application.Features.Auth.Commands.ChangePassword;
using Sprout.Api.Application.Features.Auth.Commands.ForgotPassword;
using Sprout.Api.Application.Features.Auth.Commands.Google;
using Sprout.Api.Application.Features.Auth.Commands.Login;
using Sprout.Api.Application.Features.Auth.Commands.Register;
using Sprout.Api.Application.Features.Categories.Commands.CreateCategory;
using Sprout.Api.Application.Features.Categories.Commands.DeleteCategory;
using Sprout.Api.Application.Features.Categories.Commands.UpdateCategory;
using Sprout.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using Sprout.Api.Application.Features.TaskList.Commands.CreateTaskList;
using Sprout.Api.Application.Features.TaskList.Commands.DeleteTaskList;
using Sprout.Api.Application.Features.TaskList.Commands.UpdateTaskList;
using Sprout.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using Sprout.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItem;
using Sprout.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItemCompletedStatus;

namespace Sprout.Api.Application.DependencyInjection;

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
        services.AddValidatorsFromAssemblyContaining<CreateTasklistItemCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateTaskListItemCommandValidator>();
        services.AddValidatorsFromAssemblyContaining<DeleteTaskListCommandHandler>();
        services.AddValidatorsFromAssemblyContaining<UpdateTaskListItemCompletedStatusCommand>();


        return services;
    }
}