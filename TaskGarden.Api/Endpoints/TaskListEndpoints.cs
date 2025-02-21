using MediatR;
using TaskGarden.Api.Dtos.Category;
using TaskGarden.Api.Dtos.TaskList;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Application.Features.TaskList.Commands.CreateTaskList;
using TaskGarden.Application.Features.TaskList.Commands.UpdateTaskList;
using TaskGarden.Application.Features.TaskList.Queries.GetTaskListById;
using TaskGarden.Infrastructure.Models;

namespace TaskGarden.Api.Endpoints;

public static class TaskListEndpoints
{
    public static void MapTaskListEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/task-list").WithTags("Task List");

        group.MapGet("/{taskListId:int}",
                async (GetTaskListByIdQuery query, IMediator mediator) =>
                {
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

        group.MapPut("/{taskListId:int}",
                async (UpdateTaskListCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<UpdateTaskListResponse>.SuccessResponse(response));
                })
            .WithName("UpdateTaskList")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}