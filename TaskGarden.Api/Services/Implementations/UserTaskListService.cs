using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Enums;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Api.Services.Implementations;

public class UserTaskListService : IUserTaskListService
{
    private readonly IUserTaskListRepository _userTaskListRepository;

    public UserTaskListService(IUserTaskListRepository userTaskListRepository)
    {
        _userTaskListRepository = userTaskListRepository;
    }

    public async Task<bool> AssignUserToTaskListAsync(string userId, int taskListId, TaskListRole role)
    {
        try
        {
            var userTaskList = new UserTaskList
            {
                UserId = userId,
                TaskListId = taskListId,
                Role = role.ToString()
            };

            await _userTaskListRepository.AddAsync(userTaskList);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    
    

}