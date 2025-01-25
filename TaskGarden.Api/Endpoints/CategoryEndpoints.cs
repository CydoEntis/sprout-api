using TaskGarden.Api.Dtos.Auth;
using TaskGarden.Api.Dtos.Category;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Models;

namespace TaskGarden.Api.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/category").WithTags("Category");

        group.MapPost("/",
                async (NewCategoryRequestDto newCategoryRequestDto, ICategoryService categoryService) =>
                {
                    var response = await categoryService.CreateNewCategoryAsync(newCategoryRequestDto);
                    return Results.Ok(ApiResponse<NewCategoryResponseDto>.SuccessResponse(response));
                })
            .WithName("AddCategory")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapGet("/",
                async (ICategoryService categoryService) =>
                {
                    var response = await categoryService.GetAllCategoriesAsync();
                    return Results.Ok(ApiResponse<List<CategoryWithCountResponseDto>>.SuccessResponse(response));
                })
            .WithName("GetAllCategories")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        // Update Category Endpoint
        group.MapPut("/{categoryId}",
                async (int categoryId, UpdateCategoryRequestDto updateDto, ICategoryService categoryService) =>
                {
                    var response = await categoryService.UpdateCategoryAsync(categoryId, updateDto);
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
                    await categoryService.DeleteCategoryAsync(categoryId);
                    return Results.Ok(ApiResponse<DeleteCategoryResponseDto>.SuccessResponse("Category successfully deleted."));
                })
            .WithName("DeleteCategory")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}