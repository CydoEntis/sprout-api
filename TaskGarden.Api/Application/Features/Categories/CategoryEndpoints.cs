using TaskGarden.Api.Application.Features.Categories.Commands.CreateCategory;
using TaskGarden.Api.Application.Features.Categories.Commands.DeleteCategory;
using TaskGarden.Api.Application.Features.Categories.Commands.UpdateCategory;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using TaskGarden.Api.Application.Features.Categories.Queries.GetCategoriesWithTaskListCount;
using TaskGarden.Api.Application.Features.Categories.Queries.GetCategory;
using TaskGarden.Api.Application.Features.Categories.Queries.GetRecentCategories;

namespace TaskGarden.Api.Application.Features.Categories;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapCreateCategoryEndpoint();
        routes.MapGetRecentCategoriesEndpoint();
        routes.MapGetCategoriesWithTaskListCountEndpoint();
        routes.MapGetAllCategoriesEndpoint();
        routes.MapGetAllTaskListsForCategoryEndpoint();
        routes.MapUpdateCategoryEndpoint();
        routes.MapDeleteCategoryEndpoint();
        routes.MapGetCategoryEndpoint();
    }
}