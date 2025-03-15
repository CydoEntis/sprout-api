using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskGarden.Application.Features.Categories.Commands.CreateCategory;
using TaskGarden.Application.Features.Invitation.Commands.AcceptInvite;
using TaskGarden.Application.Features.Invitation.Commands.DeclineInvite;
using TaskGarden.Infrastructure.Models;

namespace TaskGarden.Api.Endpoints;

public static class InviteEndpoints
{
    public static void MapInviteEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/invite").WithTags("Invite");

        group.MapPost("/{inviteToken}/accept",
                async (string inviteToken, [FromBody] AcceptInviteCommand command, IMediator mediator) =>
                {
                    // Ensure the command uses the correct inviteToken
                    var updatedCommand = command with { Token = inviteToken };

                    var response = await mediator.Send(updatedCommand);
                    return response
                        ? Results.Ok(ApiResponse<string>.SuccessWithMessage("Invite accepted."))
                        : Results.BadRequest(ApiResponse<string>.FailureWithMessage("Invite could not be accepted."));
                })
            .WithName("AcceptInvite")
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        group.MapPost("/{inviteToken}/decline",
                async (string inviteToken, IMediator mediator) =>
                {
                    var command = new DeclineInviteCommand(inviteToken);
                    var response = await mediator.Send(command);
                    return response
                        ? Results.Ok(ApiResponse<string>.SuccessWithMessage("Invite declined."))
                        : Results.BadRequest(ApiResponse<string>.FailureWithMessage("Invite could not be declined."));
                })
            .WithName("DeclineInvite")
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
    }
}