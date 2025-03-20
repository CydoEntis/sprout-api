using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.ReorderTaskListItem;

public static class ReorderTaskListItemEndpoint
{
    public static void MapReorderTaskListItemEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPut("/api/task-list/{taskListId}/items/reorder",
                async (ReorderTaskListItemCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<ReorderTaskListItemResponse>.SuccessWithData(response));
                })
            .WithName("ReorderTaskListItem")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}