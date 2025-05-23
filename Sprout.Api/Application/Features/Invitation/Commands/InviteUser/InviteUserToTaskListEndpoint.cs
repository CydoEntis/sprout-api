﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Application.Features.Invitation.Commands.InviteUser;

public static class InviteUserToTaskListEndpoint
{
    public static void MapInviteUserToTaskListEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/task-list/{taskListId}/invite",
                async (int taskListId, [FromBody] InviteUserCommand command, IMediator mediator) =>
                {
                    var inviteCommand = new InviteUserCommand
                    {
                        InvitedUserEmails = command.InvitedUserEmails,
                        TasklistId = taskListId,
                        Role = command.Role
                    };

                    var result = await mediator.Send(inviteCommand);
                    return result
                        ? Results.Ok(ApiResponse<string>.SuccessWithMessage("Invitation sent successfully."))
                        : Results.BadRequest(ApiResponse<string>.FailureWithMessage("Failed to send invitation."));
                })
            .WithName("InviteUser")
            .WithTags("Invite")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}