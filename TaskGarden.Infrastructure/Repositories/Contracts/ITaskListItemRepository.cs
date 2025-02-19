using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Repositories.Contracts;


public interface ITaskListItemRepository : IBaseRepository<TaskListItem>
{
    Task<IEnumerable<TaskListItem>> GetAllTasksForTaskList(int taskListId);
}