using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Common.Contracts;

public interface ITaskListMemberRepository : IBaseRepository<TaskListMember>
{
    Task<int> GetCountAsync(string userId, string categoryName);
    Task<string> GetAssignedRoleAsync(string userId, int taskListId);
    Task<TaskListMember?> GetByCategoryIdAsync(string userId, int categoryId);
    Task<TaskListMember?> GetByUserAndTaskListAsync(string userId, int taskListId);
    Task<bool> IsUserAMemberAsync(string userId, int taskListId);
}