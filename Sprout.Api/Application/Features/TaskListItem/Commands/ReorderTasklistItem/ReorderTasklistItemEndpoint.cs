using MediatR;
using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Application.Features.TaskListItem.Commands.ReorderTaskListItem;

public static class ReorderTasklistItemEndpoint
{
    public static void MapReorderTaskListItemEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPut("/api/task-list/{taskListId}/items/reorder",
                async (ReorderTasklistItemCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<ReorderTaskListItemResponse>.SuccessWithData(response));
                })
            .WithName("ReorderTaskListItem")
            .WithTags("Task List Item")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}