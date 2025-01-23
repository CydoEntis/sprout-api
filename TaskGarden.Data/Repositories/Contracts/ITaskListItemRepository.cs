using TaskGarden.Data.Models;

namespace TaskGarden.Data.Repositories.Contracts;

public interface ITaskListItemRepository
{
    Task<IEnumerable<TaskListItem>> GetAllTasksForTaskList(int taskListId);
}