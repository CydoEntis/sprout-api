using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.Categories.Commands.CreateCategory;

public static class CreateCategoryEndpoint
{
    public static void MapCreateCategoryEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/categories", async (CreateCategoryCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<CreateCategoryResponse>.SuccessWithData(response));
            })
            .WithName("AddCategory")
            .WithTags("Categories")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}