using Microsoft.Extensions.DependencyInjection;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Infrastructure.Repositories;
using TaskGarden.Infrastructure.Repositories.Implementations;

namespace TaskGarden.Infrastructure;

public static class RepositoryServiceRegistration
{
    public static IServiceCollection AddRepositoryService(this IServiceCollection services)
    {
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITaskListRepository, TaskListRepository>();
        services.AddScoped<ITaskListAssignmentRepository, TaskListMemberRepository>();
        services.AddScoped<ITaskListItemRepository, TaskListItemRepository>();
        services.AddScoped<IInvitationRepository, InvitationRepository>();

        return services;
    }
}