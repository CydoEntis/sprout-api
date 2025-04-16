using MediatR;
using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Application.Features.Tasklist.Commands.FavoriteTasklist;

public static class FavoriteTaskListEndpoint
{
    public static void MapFavoriteTasklistEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPut("/api/task-list/{taskListId}/favorite",
                async (int taskListId, IMediator mediator) =>
                {
                    var command = new FavoriteTaskListCommand(taskListId);
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<FavoriteTaskListResponse>.SuccessWithData(response));
                })
            .WithName("FavoriteTasklist")
            .WithTags("Task List")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}