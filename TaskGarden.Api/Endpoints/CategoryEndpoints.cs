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
                    return Results.Ok(ApiResponse<List<CategoryResponseDto>>.SuccessResponse(response));
                })
            .WithName("GetAllCategories")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}