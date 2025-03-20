using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;

public static class GetAllCategoriesEndpoint
{
    public static void MapGetAllCategoriesEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/category", async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetAllCategoriesQuery());
                return Results.Ok(ApiResponse<List<GetAllCategoriesQueryResponse>>.SuccessWithData(response));
            })
            .WithName("GetAllCategories")
            .WithTags("Category")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}