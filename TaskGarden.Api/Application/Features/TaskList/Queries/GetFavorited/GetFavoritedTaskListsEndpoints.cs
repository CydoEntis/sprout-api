using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.TaskList.Queries.GetFavorited;

public static class GetFavoritedTaskListsEndpoints
{
    public static void MapGetFavoritedTaskListsEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/task-list/favorites",
                async (IMediator mediator) =>
                {
                    var query = new GetFavoritedTaskListsQuery();
                    var response = await mediator.Send(query);
                    return Results.Ok(ApiResponse<List<FavoritedTasklistQueryResponse>>.SuccessWithData(response));
                })
            .WithName("GetFavoritedTaskLists")
            .WithTags("Task List")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}