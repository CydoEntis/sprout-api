using TaskGarden.Api.Application.Features.Categories.Commands.CreateCategory;
using TaskGarden.Api.Application.Features.Categories.Commands.DeleteCategory;
using TaskGarden.Api.Application.Features.Categories.Commands.UpdateCategory;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;

namespace TaskGarden.Api.Application.Features.Categories;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapCreateCategoryEndpoint();
        routes.MapGetAllCategoriesEndpoint();
        routes.MapGetAllTaskListsForCategoryEndpoint();
        routes.MapUpdateCategoryEndpoint();
        routes.MapDeleteCategoryEndpoint();
    }
}