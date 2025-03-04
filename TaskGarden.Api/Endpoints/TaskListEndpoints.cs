using MediatR;
using TaskGarden.Application.Features.TaskList.Commands.CreateTaskList;
using TaskGarden.Application.Features.TaskList.Commands.DeleteTaskList;
using TaskGarden.Application.Features.TaskList.Commands.DeleteTaskListItem;
using TaskGarden.Application.Features.TaskList.Commands.UpdateTaskList;
using TaskGarden.Application.Features.TaskList.Queries.GetTaskListById;
using TaskGarden.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using TaskGarden.Application.Features.TaskListItem.Commands.UpdateTaskListItem;
using TaskGarden.Infrastructure.Models;

namespace TaskGarden.Api.Endpoints;

public static class TaskListEndpoints
{
    public static void MapTaskListEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/task-list").WithTags("Task List");

        group.MapGet("/{taskListId:int}",
                async (int taskListId, IMediator mediator) =>
                {
                    var query = new GetTaskListByIdQuery(taskListId);
                    var response = await mediator.Send(query);
                    return Results.Ok(ApiResponse<GetTaskListByIdQueryResponse>.SuccessResponse(response));
                })
            .WithName("GetTaskListById")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapPost("/",
                async (CreateTaskListCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<CreateTaskListResponse>.SuccessResponse(response));
                })
            .WithName("CreateTaskList")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapPut("/",
                async (UpdateTaskListCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<UpdateTaskListResponse>.SuccessResponse(response));
                })
            .WithName("UpdateTaskList")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapDelete("/{taskListId}",
                async (int taskListId, IMediator mediator) =>
                {
                    var command = new DeleteTaskListCommand(taskListId);
                    var response = await mediator.Send(command);
                    return Results.Ok(
                        ApiResponse<DeleteTaskListResponse>.SuccessResponse(response));
                })
            .WithName("DeleteTaskList")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
        
        
        // Items
        
        group.MapPost("/{taskListId}/items",
                async (CreateTaskListItemCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<CreateTaskListItemResponse>.SuccessResponse(response));
                })
            .WithName("CreateTaskListItem")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapPut("/{taskListId}/items",
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

        group.MapDelete("/{taskListId}/items/{itemId}",
                async (int taskListId, IMediator mediator) =>
                {
                    var command = new DeleteTaskListItemCommand(itemId);
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