﻿using MediatR;
using Sprout.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Application.Features.TaskListItem.Commands.CreateTaskListItems;

public static class CreateTasklistItemsEndpoint
{
    public static void MapCreateTaskListItemsEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/task-list/{taskListId}/items",
                async (CreateTasklistItemsCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<CreateTaskListItemsResponse>.SuccessWithData(response));
                })
            .WithName("CreateTaskListItems")
            .WithTags("Task List Item")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}