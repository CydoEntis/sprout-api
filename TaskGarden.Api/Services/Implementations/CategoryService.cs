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

    public async Task<NewCategoryResponseDto> CreateNewCategory(CategoryRequestDto categoryRequestDto)
    {
        var existingCategory = await _categoryRepository.GetCategoryByCategoryName(categoryRequestDto.Name);
        if (existingCategory is not null) throw new ConflictException("Category already exists");

        var category = _mapper.Map<Category>(categoryRequestDto);

        await _categoryRepository.AddAsync(category);
        return new NewCategoryResponseDto() { Message = $"{category.Name} has been created" };
    }
}