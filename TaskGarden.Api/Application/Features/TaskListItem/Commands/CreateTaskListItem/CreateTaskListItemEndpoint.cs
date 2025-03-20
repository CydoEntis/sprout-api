using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;

public static class CreateTaskListItemEndpoint
{
    public static void MapCreateTaskListItemEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/task-list/{taskListId}/items",
                async (CreateTaskListItemCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<CreateTaskListItemResponse>.SuccessWithData(response));
                })
            .WithName("CreateTaskListItem")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}