using MediatR;
using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Domain.Enums;

namespace Sprout.Api.Application.Features.TasklistMembers.Commands.UpdateUserRole;

public static class UpdateUserRoleEndpoint
{
    public static void MapUpdateUserRoleEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPut("/api/task-list/{taskListId}/members/role",
                async (int taskListId, UpdateUserRoleRequest request, IMediator mediator) =>
                {
                    var command = new UpdateUserRoleCommand(taskListId, request.UserId, request.NewRole);
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<UpdateUserRoleCommandResponse>.SuccessWithData(response));
                })
            .WithName("UpdateUserRole")
            .WithTags("Task List Members")
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}

public class UpdateUserRoleRequest
{
    public string UserId { get; set; }
    public TaskListRole NewRole { get; set; }
}