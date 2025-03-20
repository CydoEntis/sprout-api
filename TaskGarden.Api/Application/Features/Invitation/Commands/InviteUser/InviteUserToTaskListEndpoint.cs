using MediatR;
using TaskGarden.Infrastructure.Models;

namespace TaskGarden.Api.Application.Features.Invitation.Commands.InviteUser;

public static class InviteUserToTaskListEndpoint
{
    public static void MapInviteUserToTaskListEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/task-list/{taskListId}/invite",
                async (int taskListId, InviteUserCommand command, IMediator mediator) =>
                {
                    var inviteCommand = new InviteUserCommand
                    {
                        InvitedUserEmail = command.InvitedUserEmail,
                        TaskListId = taskListId
                    };

                    var result = await mediator.Send(inviteCommand);
                    return result
                        ? Results.Ok(ApiResponse<string>.SuccessWithMessage("Invitation sent successfully."))
                        : Results.BadRequest(ApiResponse<string>.FailureWithMessage("Failed to send invitation."));
                })
            .WithName("InviteUser")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}