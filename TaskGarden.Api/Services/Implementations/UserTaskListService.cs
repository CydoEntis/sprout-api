using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Enums;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Api.Services.Implementations;

public class UserTaskListService : IUserTaskListService
{
    private readonly ITaskListAssignmentRepository _taskListAssignmentRepository;

    public UserTaskListService(ITaskListAssignmentRepository taskListAssignmentRepository)
    {
        _taskListAssignmentRepository = taskListAssignmentRepository;
    }

    public async Task<bool> AssignUserToTaskListAsync(string userId, int taskListId, TaskListRole role)
    {
        try
        {
            var userTaskList = new TaskListAssignments
            {
                UserId = userId,
                TaskListId = taskListId,
                Role = role.ToString()
            };

            await _taskListAssignmentRepository.AddAsync(userTaskList);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<string> GetUserRoleAsync(string userId, int taskListId)
    {
        return await _taskListAssignmentRepository.GetUserRoleForTaskListAsync(userId, taskListId);
    }

}