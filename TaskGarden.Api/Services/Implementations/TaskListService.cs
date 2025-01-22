using AutoMapper;
using TaskGarden.Api.Dtos.TaskList;
using TaskGarden.Api.Helpers;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Api.Services.Implementations;

public class TaskListService : ITaskListService
{
    private readonly ITaskListRepository _taskListRepository;
    private readonly IUserContextService _userContextService;
    private readonly IMapper _mapper;

    public TaskListService(ITaskListRepository taskListRepository, IUserContextService userContextService, IMapper mapper)
    {
        _taskListRepository = taskListRepository;
        _userContextService = userContextService;
        _mapper = mapper;
    }

    public async Task<NewTaskListResponseDto> CreateNewTaskListAsync(NewTaskListRequestDto dto)
    {
        var userId = _userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");
        
        var taskList = _mapper.Map<TaskList>(dto);
        await _taskListRepository.AddAsync(taskList);
        
        return new NewTaskListResponseDto() { Message = $"Task list created: {taskList.Id}", Id = taskList.Id };
    }
    
    public async Task<List<TaskListResponseDto>> GetAllTaskListsByCategoryAsync(string category)
    {
        var userId = _userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var taskLists =await _taskListRepository.GetAllTaskListsByCategoryForUser(userId, category);
        return _mapper.Map<List<TaskListResponseDto>>(taskLists);
    }
    
}