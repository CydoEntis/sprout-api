using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.DeleteTaskListItem;

public static class DeleteTaskListItemEndpoint
{
    public static void MapDeleteTaskListItemEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapDelete("/api/task-list/{taskListId}/items/{taskListItemId}",
                async (int taskListItemId, IMediator mediator) =>
                {
                    var command = new DeleteTaskListItemCommand(taskListItemId);
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<DeleteTaskListItemResponse>.SuccessWithData(response));
                })
            .WithName("DeleteTaskListItem")
            .WithTags("Task List Item")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}