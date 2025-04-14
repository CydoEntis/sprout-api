using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory
{
    public static class GetAllTaskListsForCategoryEndpoint
    {
        public static void MapGetAllTaskListsForCategoryEndpoint(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/categories/{category}/task-lists", async (
                    IMediator mediator,
                    [FromRoute] string category,
                    [FromQuery] int page = 1, 
                    [FromQuery] string? search = null, 
                    [FromQuery] string sortBy = "createdAt", 
                    [FromQuery] string sortDirection = "desc" 
                ) =>
                {
                    var queryWithCategory = new GetAllTaskListsForCategoryQuery(
                        CategoryName: category,
                        Page: page,
                        Search: search,
                        SortBy: sortBy,
                        SortDirection: sortDirection
                    );

                    var response = await mediator.Send(queryWithCategory);

                    return Results.Ok(
                        ApiResponse<PagedResponse<GetAllTaskListsForCategoryResponse>>.SuccessWithData(response));
                })
                .WithName("GetAllTaskListsForCategory")
                .WithTags("Categories")
                .RequireAuthorization()
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status200OK);
        }
    }
}