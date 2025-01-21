using TaskGarden.Api.Dtos.Category;

namespace TaskGarden.Api.Services.Contracts;

public interface ICategoryService
{
    Task<NewCategoryResponseDto> CreateNewCategory(NewCategoryRequestDto dto);
}