using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.TasklistMembers.Commands.RemoveUserFromTasklist;

public static class RemoveUserFromTasklistEndpoint
{
    public static void MapRemoveUserFromTasklistEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapDelete("/api/task-list/{taskListId}/members/{userId}",
                async (int taskListId, string userId, IMediator mediator) =>
                {
                    var command = new RemoveUserFromTasklistCommand(taskListId, userId);
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<RemoveUserFromTasklistCommandResponse>.SuccessWithData(response));
                })
            .WithName("RemoveUserFromTasklist")
            .WithTags("Task List Members")
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}