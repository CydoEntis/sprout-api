using TaskGarden.Api.Dtos.Category;
using TaskGarden.Api.Dtos.TaskList;

namespace TaskGarden.Api.Services.Contracts;

public interface ICategoryService
{
    Task<NewCategoryResponseDto> CreateNewCategoryAsync(NewCategoryRequestDto dto);
    Task<List<CategoryOverviewResponseDto>> GetAllCategoriesAsync();
    Task<List<TaskListResponseDto>> GetAllTaskListsInCategory(string categoryName);
    Task<UpdateCategoryResponseDto> UpdateCategoryAsync(UpdateCategoryRequestDto dto);
    Task<DeleteCategoryResponseDto> DeleteCategoryAsync(int categoryId);
}