using Microsoft.EntityFrameworkCore;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Projections;
using TaskGarden.Infrastructure.Repositories.Contracts;

namespace TaskGarden.Infrastructure.Repositories.Implementations;


public class TaskListRepository : BaseRepository<TaskList>, ITaskListRepository
{
    public TaskListRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<TaskListDetails?> GetByIdAsync(int id)
    {
        return await _context.TaskLists.Where(q => q.Id == id).Select(tl => new TaskListDetails()
        {
            Id = tl.Id,
            Name = tl.Name,
            Description = tl.Description,
            CompletedTasksCount = tl.TaskListItems.Count(q => q.IsCompleted),
            TotalTasksCount = tl.TaskListItems.Count(),
            IsCompleted = tl.IsCompleted,
            CreatedAt = tl.CreatedAt,
            Members = tl.TaskListAssignments
                .Select(tla => new Member
                {
                    Id = tla.User.Id,
                    Name = tla.User.FirstName + " " + tla.User.LastName,
                })
                .ToList(),
            TaskListItems = tl.TaskListItems.Select(q => new TaskListItemDetail
            {
                Id = q.Id,
                Description = q.Description,
                IsCompleted = q.IsCompleted
            }).ToList(),
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