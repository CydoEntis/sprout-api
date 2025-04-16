using MediatR;
using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Application.Features.Invitation.Commands.DeclineInvite;

public static class DeclineInviteEndpoint
{
    public static void MapDeclineInviteEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/task-list/{taskListId}/invitations/{token}/decline",
                async (string inviteToken, IMediator mediator) =>
                {
                    var command = new DeclineInviteCommand(inviteToken);
                    var response = await mediator.Send(command);
                    return response
                        ? Results.Ok(ApiResponse<string>.SuccessWithMessage("Invite declined."))
                        : Results.BadRequest(ApiResponse<string>.FailureWithMessage("Invite could not be declined."));
                })
            .WithName("DeclineInvite")
            .WithTags("Invite")
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
    }
}