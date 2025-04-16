using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Application.Features.Categories.Queries.GetCategory;

public static class GetCategoryEndpoint
{
    public static void MapGetCategoryEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/categories/{categoryName}", async ([FromRoute] string categoryName,
                IMediator mediator) =>
            {
                var response = await mediator.Send(new GetCategoryQuery(categoryName));
                return Results.Ok(ApiResponse<GetCategoryResponse>.SuccessWithData(response));
            })
            .WithName("GetCategory")
            .WithTags("Categories")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}