using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;

public static class GetAllTaskListsForCategoryEndpoint
{
    public static void MapGetAllTaskListsForCategoryEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/category/{category}", async (string category, IMediator mediator) =>
            {
                var query = new GetAllTaskListsForCategoryQuery(category);
                var response = await mediator.Send(query);
                return Results.Ok(ApiResponse<List<GetAllTaskListsForCategoryResponse>>.SuccessWithData(response));
            })
            .WithName("GetAllTaskListsForCategory")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}