using MediatR;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetRecentCategories;

public static class GetRecentCategoriesEndpoint
{
    public static void MapGetRecentCategoriesEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/categories/recent", async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetRecentCategoriesQuery());
                return Results.Ok(ApiResponse<List<GetRecentCategoriesQueryResponse>>.SuccessWithData(response));
            })
            .WithName("GetRecentCategories")
            .WithTags("Categories")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}