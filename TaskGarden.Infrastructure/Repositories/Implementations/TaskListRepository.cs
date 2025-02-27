using Microsoft.EntityFrameworkCore;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Infrastructure.Repositories.Implementations;

public class TaskListRepository : BaseRepository<TaskList>, ITaskListRepository
{
    public TaskListRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<TaskList?> GetByIdAsync(int id)
    {
        return await _context.TaskLists
            .FirstOrDefaultAsync(q => q.Id == id);
    }


    public async Task<TaskListDetails?> GetDetailsByIdAsync(int id)
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

    public async Task<bool> DeleteTaskListAndDependenciesAsync(TaskList taskList)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var taskListItems = await _context.TaskListItems.Where(q => q.TaskListId == taskList.Id).ToListAsync();


            if (taskListItems.Count > 0)
            {
                _context.TaskListItems.RemoveRange(taskListItems);
            }

            // TODO: In future implement the deletion of associated members of the task list.

            _context.TaskLists.Remove(taskList);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }
}