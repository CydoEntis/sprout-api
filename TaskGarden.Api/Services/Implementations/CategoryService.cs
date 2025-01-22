using AutoMapper;
using TaskGarden.Api.Dtos.Category;
using TaskGarden.Api.Errors;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CategoryService(ICategoryRepository categoryRepository, IHttpContextAccessor httpContextAccessor,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    public async Task<NewCategoryResponseDto> CreateNewCategoryAsync(NewCategoryRequestDto dto)
    {
        var userId = GetUserIdFromContext();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var existingCategory = await _categoryRepository.GetCategoryByCategoryName(dto.Name);
        if (existingCategory is not null)
            throw new ConflictException("Category already exists");

        var category = _mapper.Map<Category>(dto);
        category.UserId = userId;

        await _categoryRepository.AddAsync(category);
        return new NewCategoryResponseDto() { Message = $"{category.Name} category has been created" };
    }

    public async Task<List<CategoryResponseDto>> GetAllCategoriesAsync()
    {
        var userId = GetUserIdFromContext();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var categories = await _categoryRepository.GetAllCategoriesForUser(userId);
        return _mapper.Map<List<CategoryResponseDto>>(categories);
    }

    private string? GetUserIdFromContext()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        if (user == null || !(user.Identity?.IsAuthenticated ?? false))
        {
            return null;
        }

        return user.FindFirst("userId")?.Value;
    }
}