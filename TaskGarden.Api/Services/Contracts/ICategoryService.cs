using TaskGarden.Api.Dtos.Category;

namespace TaskGarden.Api.Services.Contracts;

public interface ICategoryService
{
    Task<NewCategoryResponseDto> CreateNewCategoryAsync(NewCategoryRequestDto dto);
    Task<List<CategoryWithCountResponseDto>> GetAllCategoriesAsync();
    Task<UpdateCategoryResponseDto> UpdateCategoryAsync(int categoryId, UpdateCategoryRequestDto dto);
    Task DeleteCategoryAsync(int categoryId);
}