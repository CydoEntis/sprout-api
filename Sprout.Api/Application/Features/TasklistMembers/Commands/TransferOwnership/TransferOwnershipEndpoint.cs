using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.TasklistMembers.Commands.TransferOwnership;

public static class TransferOwnershipEndpoint
{
    public static void MapTransferOwnershipEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPut("/api/task-list/{taskListId}/transfer-ownership/{newOwnerId}",
                async (int taskListId, string newOwnerId, IMediator mediator) =>
                {
                    var command = new TransferOwnershipCommand(taskListId, newOwnerId);
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<TransferOwnershipCommandResponse>.SuccessWithData(response));
                })
            .WithName("TransferOwnership")
            .WithTags("Task List Members")
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}