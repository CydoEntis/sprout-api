using AutoMapper;
using TaskGarden.Api.Dtos.Category;
using TaskGarden.Api.Errors;
using TaskGarden.Api.Helpers;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Enums;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITaskListRepository _taskListRepository;
    private readonly ITaskListAssignmentRepository _taskListAssignmentRepository;
    private readonly IMapper _mapper;
    private readonly IUserContextService _userContextService;

    public CategoryService(ICategoryRepository categoryRepository,
        IMapper mapper, IUserContextService userContextService,
        ITaskListAssignmentRepository taskListAssignmentRepository, ITaskListRepository taskListRepository)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _userContextService = userContextService;
        _taskListAssignmentRepository = taskListAssignmentRepository;
        _taskListRepository = taskListRepository;
    }

    public async Task<NewCategoryResponseDto> CreateNewCategoryAsync(NewCategoryRequestDto dto)
    {
        var userId = _userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var existingCategory = await _categoryRepository.GetByNameAsync(userId, dto.Name);
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


    public async Task<List<CategoriesTaskListsResponseDto>> GetAllTaskListsByCategoryAsync(string category)
    {
        var userId = _userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var taskLists = await _categoryRepository.GetAllCategoriesWithTaskListsAsync(userId, category);
        return _mapper.Map<List<CategoriesTaskListsResponseDto>>(taskLists);
    }

    public async Task<UpdateCategoryResponseDto> UpdateCategoryAsync(int categoryId, UpdateCategoryRequestDto dto)
    {
        var userId = _userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var category = await _categoryRepository.GetAsync(categoryId);
        if (category == null)
            throw new NotFoundException("Category not found.");

        if (category.UserId != userId)
            throw new PermissionException("You are not the owner of this category.");

        _mapper.Map(dto, category);
        await _categoryRepository.UpdateAsync(category);
        return new UpdateCategoryResponseDto { Message = $"{category.Name} category has been updated successfully" };
    }

    public async Task DeleteCategoryAsync(int categoryId)
    {
        var userId = _userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var category = await _categoryRepository.GetAsync(categoryId);
        if (category == null)
            throw new NotFoundException("Category not found.");

        if (category.UserId != userId)
            throw new PermissionException("You are not the owner of this category.");

        var tasksListsToDelete = await _taskListRepository.GetAllByCategoryIdAsync(categoryId);
        if (tasksListsToDelete.Count != 0)
        {
            var taskListIds = tasksListsToDelete.Select(t => t.Id).ToList();
            var taskListAssignmentsToDelete = await _taskListAssignmentRepository.
            
            
            await _taskListRepository.DeleteRangeAsync(tasksListsToDelete);
        }
        
        


        foreach (var taskList in category.TaskLists)
        {
            await _taskListAssignmentRepository.DeleteAsync(taskList.Id);
        }

        await _categoryRepository.DeleteAsync(categoryId);
    }
}