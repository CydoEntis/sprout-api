using TaskGarden.Api.Services.Contracts;

namespace TaskGarden.Api.Services.Implementations;

public class TaskListService : ITaskListService
{
    private readonly ITaskListRepository _taskListRepository;
}