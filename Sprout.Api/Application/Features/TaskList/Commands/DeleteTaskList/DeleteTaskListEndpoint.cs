﻿using MediatR;
using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Application.Features.TaskList.Commands.DeleteTaskList;

public static class DeleteTaskListEndpoint
{
    public static void MapDeleteTaskListEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapDelete("/api/task-list/{taskListId}", async (int taskListId, IMediator mediator) =>
            {
                var command = new DeleteTaskListCommand(taskListId);
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<DeleteTaskListResponse>.SuccessWithData(response));
            })
            .WithName("DeleteTaskList")
            .WithTags("Task List")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}