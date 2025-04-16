using MediatR;
using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Application.Features.TaskListItem.Commands.DeleteTaskListItem;

public static class DeleteTasklistItemEndpoint
{
    public static void MapDeleteTaskListItemEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapDelete("/api/task-list/{taskListId}/items/{taskListItemId}",
                async (int taskListItemId, IMediator mediator) =>
                {
                    var command = new DeleteTasklistItemCommand(taskListItemId);
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