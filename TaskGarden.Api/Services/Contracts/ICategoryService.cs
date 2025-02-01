using TaskGarden.Api.Dtos.Category;

namespace TaskGarden.Api.Services.Contracts;

public interface ICategoryService
{
    Task<NewCategoryResponseDto> CreateNewCategoryAsync(NewCategoryRequestDto dto);
    Task<List<CategoryOverviewResponseDto>> GetAllCategoriesAsync();
    // Task<List<CategoriesTaskListsResponseDto>> GetAllTaskListsInCategory(string categoryName);
    Task<UpdateCategoryResponseDto> UpdateCategoryAsync(int categoryId, UpdateCategoryRequestDto dto);
    Task DeleteCategoryAsync(int categoryId);
}