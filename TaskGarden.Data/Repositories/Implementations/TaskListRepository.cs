using Microsoft.EntityFrameworkCore;
using TaskGarden.Data.Models;
using TaskGarden.Data.Models.Member;
using TaskGarden.Data.Projections;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Data.Repositories;

public class TaskListRepository : BaseRepository<TaskList>, ITaskListRepository
{
    public TaskListRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<TaskListOverview?> GetByIdAsync(string userId, int id)
    {
        return await _context.TaskLists.Where(q => q.Id == id).Select(tl => new TaskListOverview
        {
            Id = tl.Id,
            Name = tl.Name,
            Description = tl.Description,
            CreatedAt = tl.CreatedAt,
            UpdatedAt = tl.UpdatedAt,
            Members = tl.TaskListAssignments
                .Select(tla => new Member
                {
                    Id = tla.User.Id,
                    Name = tla.User.FirstName + " " + tla.User.LastName,
                })
                .ToList(),
            TotalTasksCount = tl.TaskListItems.Count(),
            CompletedTasksCount = tl.TaskListItems.Count(q => q.IsCompleted),
            TaskCompletionPercentage = tl.TaskListItems.Count() == 0
                ? 0
                : (double)tl.TaskListItems.Count(q => q.IsCompleted) / tl.TaskListItems.Count() * 100
        }).FirstOrDefaultAsync();
    }

    public async Task<List<TaskListOverview>> GetAllTaskListsInCategoryAsync(int categoryId)
    {
        return await _context.TaskLists
            .Where(t => t.CategoryId == categoryId)
            .Select(tl => new TaskListOverview
            {
                Id = tl.Id,
                Name = tl.Name,
                Description = tl.Description,
                CreatedAt = tl.CreatedAt,
                UpdatedAt = tl.UpdatedAt,
                Members = tl.TaskListAssignments
                    .Select(tla => new Member
                    {
                        Id = tla.User.Id,
                        Name = tla.User.FirstName + " " + tla.User.LastName,
                    })
                    .ToList(),
                TotalTasksCount = tl.TaskListItems.Count(),
                CompletedTasksCount = tl.TaskListItems.Count(q => q.IsCompleted),
                TaskCompletionPercentage = tl.TaskListItems.Count() == 0
                    ? 0
                    : (double)tl.TaskListItems.Count(q => q.IsCompleted) / tl.TaskListItems.Count() * 100
            })
            .ToListAsync();
    }
}