using MediatR;
using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Application.Features.Invitation.Commands.AcceptInvite;

public static class AcceptInviteEndpoint
{
    public static void MapAcceptInviteEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/task-list/{taskListId}/invitations/{inviteToken}/accept",
                async (string inviteToken, AcceptInviteCommand command, IMediator mediator) =>
                {
                    var updatedCommand = command with { Token = inviteToken };
                    var response = await mediator.Send(updatedCommand);
                    return Results.Ok(ApiResponse<AcceptInviteCommandResponse>.SuccessWithData(response));
                })
            .WithName("AcceptInvite")
            .WithTags("Invite")
            .RequireAuthorization()
            .Produces<AcceptInviteCommandResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
    }
}