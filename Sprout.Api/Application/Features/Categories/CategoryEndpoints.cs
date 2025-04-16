using Sprout.Api.Application.Features.Categories.Commands.CreateCategory;
using Sprout.Api.Application.Features.Categories.Commands.DeleteCategory;
using Sprout.Api.Application.Features.Categories.Commands.UpdateCategory;
using Sprout.Api.Application.Features.Categories.Queries.GetAllCategories;
using Sprout.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using Sprout.Api.Application.Features.Categories.Queries.GetCategoriesWithTaskListCount;
using Sprout.Api.Application.Features.Categories.Queries.GetCategory;
using Sprout.Api.Application.Features.Categories.Queries.GetRecentCategories;

namespace Sprout.Api.Application.Features.Categories;

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