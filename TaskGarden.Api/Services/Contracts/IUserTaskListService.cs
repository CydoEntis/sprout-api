using TaskGarden.Data.Enums;

namespace TaskGarden.Api.Services.Contracts;

public interface IUserTaskListService
{
    Task<bool> AssignUserToTaskListAsync(string userId, int taskListId, TaskListRole role);
    Task<string> GetUserRoleAsync(string userId, int taskListId);
}