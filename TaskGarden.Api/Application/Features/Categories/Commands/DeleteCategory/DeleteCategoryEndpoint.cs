using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.Categories.Commands.DeleteCategory;

public static class DeleteCategoryEndpoint
{
    public static void MapDeleteCategoryEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapDelete("/api/categories/{categoryId}", async (int categoryId, IMediator mediator) =>
            {
                var command = new DeleteCategoryCommand(categoryId);
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<DeleteCategoryResponse>.SuccessWithData(response));
            })
            .WithName("DeleteCategory")
            .WithTags("Categories")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}