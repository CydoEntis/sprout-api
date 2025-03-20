using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskGarden.Api.Application.Features.Invitation.Commands.AcceptInvite;
using TaskGarden.Api.Application.Features.Invitation.Commands.DeclineInvite;
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
                    var updatedCommand = command with { Token = inviteToken };
                    var response = await mediator.Send(updatedCommand);
                    return Results.Ok(ApiResponse<AcceptInviteCommandResponse>.SuccessWithData(response));
                })
            .WithName("AcceptInvite")
            .RequireAuthorization()
            .Produces<AcceptInviteCommandResponse>(StatusCodes.Status200OK) // Specify the correct response type
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