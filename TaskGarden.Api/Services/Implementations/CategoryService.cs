using AutoMapper;
using TaskGarden.Api.Dtos.Category;
using TaskGarden.Api.Errors;
using TaskGarden.Api.Helpers;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserTaskListRepository _userTaskListRepository;
    private readonly IMapper _mapper;
    private readonly IUserContextService _userContextService;

    public CategoryService(ICategoryRepository categoryRepository,
        IMapper mapper, IUserContextService userContextService, IUserTaskListRepository userTaskListRepository)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _userContextService = userContextService;
        _userTaskListRepository = userTaskListRepository;
    }

    public async Task<NewCategoryResponseDto> CreateNewCategoryAsync(NewCategoryRequestDto dto)
    {
        var userId = _userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var existingCategory = await _categoryRepository.GetCategoryByCategoryNameAsync(dto.Name);
        if (existingCategory is not null)
            throw new ConflictException("Category already exists");

        var category = _mapper.Map<Category>(dto);
        category.UserId = userId;

        await _categoryRepository.AddAsync(category);
        return new NewCategoryResponseDto() { Message = $"{category.Name} category has been created" };
    }

    public async Task<List<CategoryWithCountResponseDto>> GetAllCategoriesAsync()
    {
        var userId = _userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var categories = await _categoryRepository.GetCategoriesWithTaskListCountsForUserAsync(userId);
        return _mapper.Map<List<CategoryWithCountResponseDto>>(categories);
    }
}