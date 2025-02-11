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

    // TODO: Remove this because its less performant.
    public async Task<List<TaskList>> GetAllTaskListsInCategoryAsync(int categoryId)
    {
        return await _context.TaskLists.Where(t => t.CategoryId == categoryId)
            .Include(t => t.TaskListItems)
            .Include(t => t.TaskListAssignments)
            .ThenInclude(tla => tla.User)
            .ToListAsync();
    }
    
    // Used projection for better queries.
    public async Task<List<TaskListOverview>> GetAllTaskListsInCategoryAsync(int categoryId)
    {
        return await _context.TaskLists
            .Where(t => t.CategoryId == categoryId)
            .Select(tl => new TaskListOverview
            {
                Id = tl.Id,
                Description = tl.Description,
                CreatedAt = tl.CreatedAt,
                UpdatedAt = tl.UpdatedAt,
                Members = tl.TaskListAssignments
                    .Select(tla => new Members
                    {
                        Id = tla.User.Id,
                        Name = tla.User.FirstName + " " + tla.User.LastName,
                    })
                    .ToList(), // Ensure materialization
                TotalTasksCount = tl.TaskListItems.Count(), // Corrected to count tasks instead of assignments
                CompletedTasksCount = tl.TaskListItems.Count(q => q.IsCompleted),
                TaskCompletionPercentage = tl.TaskListItems.Count() == 0 
                    ? 0 
                    : (double)tl.TaskListItems.Count(q => q.IsCompleted) / tl.TaskListItems.Count() * 100
            })
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

public class TaskListOverview
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Members> Members { get; set; }
    public int TotalTasksCount { get; set; }
    public int CompletedTasksCount { get; set; }
    public double TaskCompletionPercentage { get; set; }
    
}

public class Members
{
    public string Id { get; set; }
    public string Name { get; set; }
}