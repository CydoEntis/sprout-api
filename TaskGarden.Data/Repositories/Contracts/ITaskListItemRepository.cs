using TaskGarden.Data.Models;

namespace TaskGarden.Data.Repositories.Contracts;

public interface ITaskListItemRepository : IBaseRepository<TaskListItem>
{
    Task<IEnumerable<TaskListItem>> GetAllTasksForTaskList(int taskListId);
}