using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;

public static class GetAllTasklistsForCategoryEndpoint
{
    public static void MapGetAllTaskListsForCategoryEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/categories/{category}", async (string category, IMediator mediator) =>
            {
                var query = new GetAllTasklistsForCategoryQuery(category);
                var response = await mediator.Send(query);
                return Results.Ok(ApiResponse<GetAllTasklistsForCategoryResponse>.SuccessWithData(response));
            })
            .WithName("GetAllTaskListsForCategory")
            .WithTags("Categories")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}