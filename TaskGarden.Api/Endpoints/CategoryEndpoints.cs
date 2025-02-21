using MediatR;
using TaskGarden.Application.Features.Categories.Commands.CreateCategory;
using TaskGarden.Application.Features.Categories.Commands.DeleteCategory;
using TaskGarden.Application.Features.Categories.Commands.UpdateCategory;
using TaskGarden.Application.Features.Categories.Queries.GetAllCategories;
using TaskGarden.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using TaskGarden.Infrastructure.Models;

namespace TaskGarden.Api.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/category").WithTags("Category");

        group.MapPost("/",
                async (CreateCategoryCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<CreateCategoryResponse>.SuccessResponse(response));
                })
            .WithName("AddCategory")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapGet("/",
                async (IMediator mediator) =>
                {
                    var response = await mediator.Send(new GetAllCategoriesQuery());
                    return Results.Ok(ApiResponse<List<GetAllCategoriesQueryResponse>>.SuccessResponse(response));
                })
            .WithName("GetAllCategories")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapGet("/{category}",
                async (string category, IMediator mediator) =>
                {
                    var query = new GetAllTaskListsForCategoryQuery(category);
                    var response = await mediator.Send(query);
                    return Results.Ok(ApiResponse<List<GetAllTaskListsForCategoryResponse>>.SuccessResponse(response));
                })
            .WithName("GetTaskListByCategory")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapPut("/",
                async (UpdateCategoryCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<UpdateCategoryResponse>.SuccessResponse(response));
                })
            .WithName("UpdateCategory")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);

        // Delete Category Endpoint
        group.MapDelete("/{categoryId}",
                async (int categoryId, IMediator mediator) =>
                {
                    var command = new DeleteCategoryCommand(categoryId);
                    var response = await mediator.Send(command);
                    return Results.Ok(
                        ApiResponse<DeleteCategoryResponse>.SuccessResponse(response));
                })
            .WithName("DeleteCategory")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}