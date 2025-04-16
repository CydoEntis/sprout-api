using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sprout.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Application.Features.TaskList.Queries.GetFavorited
{
    public static class GetFavoritedTaskListsEndpoints
    {
        public static void MapGetFavoritedTaskListsEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/task-list/favorites", async (
                    IMediator mediator,
                    [FromQuery] int page,
                    [FromQuery] string? search,
                    [FromQuery] string sortBy,
                    [FromQuery] string sortDirection
                ) =>
                {
                    var query = new GetFavoritedTaskListsQuery(
                        Page: page,
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