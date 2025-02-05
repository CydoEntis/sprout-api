using Microsoft.EntityFrameworkCore;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class TaskListRepository : BaseRepository<TaskList>, ITaskListRepository
{
    public TaskListRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<TaskList?> GetByIdAsync(string userId, int id)
    {
        return await _context.TaskLists.Where(tl => tl.CreatedById == userId && tl.Id == id)
            .Include(tl => tl.TaskListAssignments)
                .ThenInclude(ta => ta.User)
            .Include(tl => tl.TaskListItems)
            .FirstOrDefaultAsync();
    }

    public async Task<List<TaskList>> GetAllTaskListsInCategoryAsync(int categoryId)
    {
        return await _context.TaskLists.Where(t => t.CategoryId == categoryId)
            .Include(t => t.TaskListItems)
            .Include(t => t.TaskListAssignments)
            .ThenInclude(tla => tla.User)
            .ToListAsync();
    }

    public async Task<List<TaskList>> GetAllByCategoryIdAsync(int categoryId)
    {
        return await _context.TaskLists.Where(tl => tl.Category.Id == categoryId)
            .ToListAsync();
    }

    public async Task<TaskList?> GetByUserIdAsync(string userId, int taskListId)
    {
        return await _context.TaskLists
            .Include(t => t.TaskListAssignments)
            .ThenInclude(utl => utl.User)
            .Include(t => t.TaskListItems)
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == taskListId &&
                                      t.TaskListAssignments.Any(utl => utl.UserId == userId));
    }

    public async Task<List<TaskList>> GetByCategoryIdAsync(string userId, int categoryId)
    {
        return await _context.TaskLists.Include(tl => tl.Category)
            .Where(tl => tl.CreatedById == userId && tl.CategoryId == categoryId).ToListAsync();
    }
}