using TaskGarden.Api.Application.Features.TasklistItem.Queries;
using TaskGarden.Api.Application.Features.TasklistMembers.Commands.RemoveUserFromTasklist;
using TaskGarden.Api.Application.Features.TasklistMembers.Commands.TransferOwnership;
using TaskGarden.Api.Application.Features.TasklistMembers.Commands.UpdateUserRole;
using TaskGarden.Api.Application.Features.TasklistMembers.Queries.GetTasklistMembers;

public static class TasklistMemberEndpoints
{
    public static void MapTasklistMemberEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGetTasklistMembersEndpoint();
        routes.MapRemoveUserFromTasklistEndpoint();
        routes.MapUpdateUserRoleEndpoint();
        routes.MapTransferOwnershipEndpoint();
    }
}