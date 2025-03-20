using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.Categories.Commands.UpdateCategory;

public static class UpdateCategoryEndpoint
{
    public static void MapUpdateCategoryEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPut("/api/category", async (UpdateCategoryCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<UpdateCategoryResponse>.SuccessWithData(response));
            })
            .WithName("UpdateCategory")
            .WithTags("Category")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}