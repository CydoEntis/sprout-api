using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Common.Contracts;

public interface ITaskListAssignmentRepository : IBaseRepository<TaskListMember>
{
    Task<int> GetCountAsync(string userId, string categoryName);
    Task<string> GetAssignedRoleAsync(string userId, int taskListId);
    Task<TaskListMember?> GetByCategoryIdAsync(string userId, int categoryId);
}