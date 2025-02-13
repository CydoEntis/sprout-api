using AutoMapper;
using TaskGarden.Api.Dtos.TaskList;
using TaskGarden.Api.Errors;
using TaskGarden.Api.Helpers;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Enums;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Api.Services.Implementations;

public class TaskListService : ITaskListService
{
    private readonly ITaskListRepository _taskListRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITaskListAssignmentRepository _taskListAssignmentRepository;
    private readonly IUserContextService _userContextService;
    private readonly IMapper _mapper;

    public TaskListService(ITaskListRepository taskListRepository, IUserContextService userContextService,
        IMapper mapper, ITaskListAssignmentRepository taskListAssignmentRepository,
        ICategoryRepository categoryRepository)
    {
        _taskListRepository = taskListRepository;
        _userContextService = userContextService;
        _mapper = mapper;
        _taskListAssignmentRepository = taskListAssignmentRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<NewTaskListResponseDto> CreateNewTaskListAsync(NewTaskListRequestDto dto)
    {
        var userId = _userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var category = await _categoryRepository.GetByNameAsync(userId, dto.CategoryName);

        var taskList = _mapper.Map<TaskList>(dto);
        taskList.CreatedById = userId;
        taskList.CategoryId = category.Id;


        await _taskListRepository.AddAsync(taskList);
        var response = await AssignUserToTaskListAsync(userId, taskList.Id, TaskListRole.Owner);
        if (!response)
            throw new ResourceCreationException("Unable to assign user to task list.");

        return new NewTaskListResponseDto() { Message = $"Task list created: {taskList.Id}", Id = taskList.Id };
    }
    

    public async Task<TaskListDetailsResponseDto> GetTaskListByIdAsync(int taskListId)
    {
        var userId = _userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");
    
        var taskLists = await _taskListRepository.GetByIdAsync(taskListId);
        return _mapper.Map<TaskListDetailsResponseDto>(taskLists);
    }

    public async Task UpdateTaskListAsync(int taskListId, UpdateTaskListRequestDto dto)
    {
        var userId = _userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");
    
        var userRoleString = await _taskListAssignmentRepository.GetAssignedRoleAsync(userId, taskListId);
    
        if (!Enum.TryParse<TaskListRole>(userRoleString, out var userRole))
        {
            throw new PermissionException("Invalid role");
        }
    
        if (userRole != TaskListRole.Owner && userRole != TaskListRole.Editor)
            throw new PermissionException("You do not have permission to update this task list");
    
    
        var taskList = await _taskListRepository.GetAsync(taskListId);
        if (taskList == null)
            throw new NotFoundException("Task list not found");
        
        var category = await _categoryRepository.GetByNameAsync(userId, dto.CategoryName);
        if(category == null) 
            throw new NotFoundException("Category not found");
        
        _mapper.Map(dto, taskList); 

        taskList.CategoryId = category.Id;
        taskList.UpdatedAt = DateTime.UtcNow; 

        await _taskListRepository.UpdateAsync(taskList);
        
    }
    
    
    
    private async Task<bool> AssignUserToTaskListAsync(string userId, int taskListId, TaskListRole role)
    {
        try
        {
            var userTaskList = new TaskListAssignments
            {
                UserId = userId,
                TaskListId = taskListId,
                Role = role.ToString()
            };

            await _taskListAssignmentRepository.AddAsync(userTaskList);
            return true;
        }
        catch
        {
            return false;
        }
    }
    
}