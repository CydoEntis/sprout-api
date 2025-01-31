using Microsoft.EntityFrameworkCore;
using TaskGarden.Data.Enums;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class TaskListAssignmentRepository : BaseRepository<TaskListAssignments>, ITaskListAssignmentRepository
{
    public TaskListAssignmentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<int> GetCountAsync(string userId, string categoryName)
    {
        return await _context.UserTaskLists
            .Where(utl => utl.UserId == userId)
            .Include(utl => utl.TaskList)
            .Where(utl => utl.TaskList.Category.Name == categoryName)
            .CountAsync();
    }

    public async Task<string> GetAssignedRoleAsync(string userId, int taskListId)
    {
        var taskListUserRole = await _context.UserTaskLists
            .Where(tl => tl.TaskListId == taskListId && tl.UserId == userId)
            .FirstOrDefaultAsync();

        return taskListUserRole.Role;
    }
    
    public async Task<TaskListAssignments?> GetByCategoryIdAsync(string userId, int categoryId)
    {
        return await _context.UserTaskLists
            .Where(ut => ut.UserId == userId)
            .Include(ut => ut.TaskList)
            .FirstOrDefaultAsync(ut => ut.TaskList.CategoryId == categoryId);
    }
}