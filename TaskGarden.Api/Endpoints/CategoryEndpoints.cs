using MediatR;
using TaskGarden.Api.Dtos.Category;
using TaskGarden.Api.Dtos.TaskList;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Application.Features.Categories.Commands.CreateCategory;
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
                async (ICategoryService categoryService) =>
                {
                    var response = await categoryService.GetAllCategoriesAsync();
                    return Results.Ok(ApiResponse<List<CategoryOverviewResponseDto>>.SuccessResponse(response));
                })
            .WithName("GetAllCategories")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapGet("/{category}",
                async (string category, ICategoryService categoryService) =>
                {
                    var response = await categoryService.GetAllTaskListsInCategory(category);
                    return Results.Ok(ApiResponse<List<TaskListResponseDto>>.SuccessResponse(response));
                })
            .WithName("GetTaskListByCategory")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        // Update Category Endpoint
        group.MapPut("/",
                async (UpdateCategoryRequestDto updateDto, ICategoryService categoryService) =>
                {
                    var response = await categoryService.UpdateCategoryAsync(updateDto);
                    return Results.Ok(ApiResponse<UpdateCategoryResponseDto>.SuccessResponse(response));
                })
            .WithName("UpdateCategory")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);

        // Delete Category Endpoint
        group.MapDelete("/{categoryId}",
                async (int categoryId, ICategoryService categoryService) =>
                {
                    var response = await categoryService.DeleteCategoryAsync(categoryId);
                    return Results.Ok(
                        ApiResponse<DeleteCategoryResponseDto>.SuccessResponse(response));
                })
            .WithName("DeleteCategory")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}