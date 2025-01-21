using AutoMapper;
using TaskGarden.Api.Dtos.Category;
using TaskGarden.Api.Errors;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Api.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<NewCategoryResponseDto> CreateNewCategory(NewCategoryRequestDto dto)
    {
        var existingCategory = await _categoryRepository.GetCategoryByCategoryName(dto.Name);
        if (existingCategory is not null) throw new ConflictException("Category already exists");

        var category = _mapper.Map<Category>(dto);

        await _categoryRepository.AddAsync(category);
        return new NewCategoryResponseDto() { Message = $"{category.Name} has been created" };
    }
}