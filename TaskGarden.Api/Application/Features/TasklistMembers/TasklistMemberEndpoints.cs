using TaskGarden.Api.Application.Features.TasklistItem.Queries;
using TaskGarden.Api.Application.Features.TasklistMembers.Commands.RemoveUserFromTasklist;
using TaskGarden.Api.Application.Features.TasklistMembers.Commands.UpdateUserRole;

public static class TasklistMemberEndpoints
{
    public static void MapTasklistMemberEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGetTasklistItemsEndpoint();
        routes.MapRemoveUserFromTasklistEndpoint();
        routes.MapUpdateUserRoleEndpoint();
    }
}