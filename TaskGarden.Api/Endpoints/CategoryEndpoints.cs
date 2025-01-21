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
                    var response = await categoryService.CreateNewCategory(newCategoryRequestDto);
                    return Results.Ok(ApiResponse<NewCategoryResponseDto>.SuccessResponse(response));
                })
            .WithName("Add Category")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}