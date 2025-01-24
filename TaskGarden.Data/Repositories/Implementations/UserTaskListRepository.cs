using Microsoft.EntityFrameworkCore;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class UserTaskListRepository : BaseRepository<UserTaskList>, IUserTaskListRepository
{
    public UserTaskListRepository(AppDbContext context) : base(context)
    {
    }


    public async Task<int> GetTaskListCountByCategoryForUserAsync(string userId, string categoryName)
    {
        return await _context.UserTaskLists
            .Where(utl => utl.UserId == userId)
            .Include(utl => utl.TaskList)
            .Where(utl => utl.TaskList.Category == categoryName)
            .CountAsync();
    }
}