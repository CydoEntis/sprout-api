using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetCategoriesWithTaskTaskListCount;

public static class GetCategoriesWithTaskListCountEndpoint
{
    public static void MapGetCategoriesWithTaskListCountEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/categories/details", async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetCategoriesWithTaskListCountQuery());

                return Results.Ok(
                    ApiResponse<PagedResponse<GetCategoriesWithTaskListCountResponse>>.SuccessWithData(response));
            })
            .WithName("GetAllCategoriesWithTaskListCount")
            .WithTags("Categories")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}