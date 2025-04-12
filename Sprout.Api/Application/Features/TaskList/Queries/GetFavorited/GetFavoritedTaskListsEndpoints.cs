using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.TaskList.Queries.GetFavorited
{
    public static class GetFavoritedTaskListsEndpoints
    {
        public static void MapGetFavoritedTaskListsEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/task-list/favorites", async (
                    IMediator mediator,
                    [FromQuery] int page,
                    [FromQuery] int pageSize,
                    [FromQuery] string? search,
                    [FromQuery] string sortBy,
                    [FromQuery] string sortDirection
                ) =>
                {
                    var query = new GetFavoritedTaskListsQuery(
                        Page: page,
                        PageSize: pageSize,
                        Search: search,
                        SortBy: sortBy,
                        SortDirection: sortDirection
                    );

                    var response = await mediator.Send(query);

                    return Results.Ok(
                        ApiResponse<PagedResponse<FavoritedTasklistQueryResponse>>.SuccessWithData(response));
                })
                .WithName("GetFavoritedTaskLists")
                .WithTags("Task List")
                .RequireAuthorization()
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status200OK);
        }
    }
}