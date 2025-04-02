﻿using MediatR;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Enums;

namespace TaskGarden.Api.Application.Features.TasklistMembers.Commands.UpdateUserRole;

public static class UpdateUserRoleEndpoint
{
    public static void MapUpdateUserRoleEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPut("/api/task-list/{taskListId}/members/{userId}/role",
                async (int taskListId, string userId, UpdateUserRoleRequest request, IMediator mediator) =>
                {
                    var command = new UpdateUserRoleCommand(taskListId, userId, request.NewRole);
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<UpdateUserRoleCommandResponse>.SuccessWithData(response));
                })
            .WithName("UpdateUserRole")
            .WithTags("Task List Members")
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}

public record UpdateUserRoleRequest(TaskListRole NewRole);