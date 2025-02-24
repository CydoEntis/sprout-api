using MediatR;
using TaskGarden.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using TaskGarden.Infrastructure.Models;

namespace TaskGarden.Api.Endpoints;

public static class TaskListItemEndpoints
{
    public static void MapTaskListItemEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/task-list-item").WithTags("Task List Items");

        group.MapPost("/",
                async (CreateTaskListItemCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<CreateTaskListItemResponse>.SuccessResponse(response));
                })
            .WithName("CreateTaskListItem")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
   
    }
}