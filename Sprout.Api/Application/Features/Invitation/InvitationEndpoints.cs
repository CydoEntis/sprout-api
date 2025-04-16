using Sprout.Api.Application.Features.Invitation.Commands.AcceptInvite;
using Sprout.Api.Application.Features.Invitation.Commands.DeclineInvite;
using Sprout.Api.Application.Features.Invitation.Commands.InviteUser;


namespace Sprout.Api.Application.Features.Invitation;

public static class InvitationEndpoints
{
    public static void MapInvitationEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapAcceptInviteEndpoint();
        routes.MapDeclineInviteEndpoint();
        routes.MapInviteUserToTaskListEndpoint();
    }
}