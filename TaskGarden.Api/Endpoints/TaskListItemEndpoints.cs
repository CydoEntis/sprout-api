using MediatR;
using TaskGarden.Application.Features.TaskList.Commands.DeleteTaskListItem;
using TaskGarden.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using TaskGarden.Application.Features.TaskListItem.Commands.UpdateTaskListItem;
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

        group.MapPut("/",
                async (UpdateTaskListItemCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<UpdateTaskListItemResponse>.SuccessResponse(response));
                })
            .WithName("UpdateTaskListItem")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);

        // Delete Category Endpoint
        group.MapDelete("/{taskListId}",
                async (int taskListId, IMediator mediator) =>
                {
                    var command = new DeleteTaskListItemCommand(taskListId);
                    var response = await mediator.Send(command);
                    return Results.Ok(
                        ApiResponse<DeleteTaskListItemResponse>.SuccessResponse(response));
                })
            .WithName("DeleteTaskListItem")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}