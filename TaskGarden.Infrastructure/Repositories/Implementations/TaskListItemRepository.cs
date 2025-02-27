using Microsoft.EntityFrameworkCore;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Repositories.Implementations;

public class TaskListItemRepository : BaseRepository<TaskListItem>, ITaskListItemRepository
{
    public TaskListItemRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TaskListItem>> GetAllTasksForTaskList(int taskListId)
    {
        return await _context.TaskListItems.Where(t => t.TaskListId == taskListId).ToListAsync();
    }

    public async Task<TaskListItem> GetByIdAsync(int taskListItemId)
    {
        return await _context.TaskListItems.FirstOrDefaultAsync(q => q.Id == taskListItemId);
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