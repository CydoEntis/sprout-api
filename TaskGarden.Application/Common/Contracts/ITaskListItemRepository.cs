using TaskGarden.Application.Common.Models;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Common.Contracts;

public interface ITaskListItemRepository : IBaseRepository<TaskListItem>
{
    Task<TaskListItem> AddTaskListItemAsync(TaskListItem taskListItem);
    Task<IEnumerable<TaskListItem>> GetAllTasksForTaskList(int taskListId);
    Task<TaskListItem> GetByIdAsync(int taskListItemId);
    Task ReorderTaskListItemsAsync(int taskListId, List<ListItemOrder> items);
}