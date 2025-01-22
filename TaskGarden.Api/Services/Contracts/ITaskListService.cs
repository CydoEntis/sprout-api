using TaskGarden.Api.Dtos.TaskList;

namespace TaskGarden.Api.Services.Contracts;

public interface ITaskListService
{
    Task<NewTaskListResponseDto> CreateNewTaskListAsync(NewTaskListRequestDto dto);
    Task<List<TaskListResponseDto>> GetAllTaskListsByCategoryAsync(string category);
}