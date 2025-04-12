using MediatR;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;

public static class GetAllCategoriesEndpoint
{
    public static void MapGetAllCategoriesEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/categories", async (
                IMediator mediator) =>
            {
                var response = await mediator.Send(new GetAllCategoriesQuery());
                return Results.Ok(ApiResponse<List<GetAllCategoriesResponse>>.SuccessWithData(response));
            })
            .WithName("GetAllCategories")
            .WithTags("Categories")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}