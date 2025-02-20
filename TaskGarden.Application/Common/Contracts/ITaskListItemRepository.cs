using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Common.Contracts;
public interface ITaskListItemRepository : IBaseRepository<TaskListItem>
{
    Task<IEnumerable<TaskListItem>> GetAllTasksForTaskList(int taskListId);
}