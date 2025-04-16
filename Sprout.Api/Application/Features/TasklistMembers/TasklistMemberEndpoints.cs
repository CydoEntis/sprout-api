using Sprout.Api.Application.Features.TasklistItem.Queries;
using Sprout.Api.Application.Features.TasklistMembers.Commands.RemoveUserFromTasklist;
using Sprout.Api.Application.Features.TasklistMembers.Commands.TransferOwnership;
using Sprout.Api.Application.Features.TasklistMembers.Commands.UpdateUserRole;
using Sprout.Api.Application.Features.TasklistMembers.Queries.GetTasklistMembers;

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