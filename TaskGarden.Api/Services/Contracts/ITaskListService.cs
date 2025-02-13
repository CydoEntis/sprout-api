using TaskGarden.Api.Dtos.TaskList;

namespace TaskGarden.Api.Services.Contracts;

public interface ITaskListService
{
    Task<TaskListDetailsResponseDto> GetTaskListByIdAsync(int taskListId);
    Task<NewTaskListResponseDto> CreateNewTaskListAsync(NewTaskListRequestDto dto);
    Task<UpdateTaskListResponseDto> UpdateTaskListAsync(int taskListId, UpdateTaskListRequestDto dto);
}