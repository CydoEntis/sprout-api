using TaskGarden.Api.Application.Features.Invitation.Commands.AcceptInvite;
using TaskGarden.Api.Application.Features.Invitation.Commands.DeclineInvite;
using TaskGarden.Api.Application.Features.Invitation.Commands.InviteUser;


namespace TaskGarden.Api.Application.Features.Invitation;

public static class InvitationEndpoints
{
    public static void MapInvitationEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapAcceptInviteEndpoint();
        routes.MapDeclineInviteEndpoint();
        routes.MapInviteUserToTaskListEndpoint();
    }
}