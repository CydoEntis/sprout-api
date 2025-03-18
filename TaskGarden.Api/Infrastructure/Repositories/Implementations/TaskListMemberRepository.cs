using Microsoft.EntityFrameworkCore;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Infrastructure.Repositories.Implementations;

public class TaskListMemberRepository : BaseRepository<TaskListMember>, ITaskListMemberRepository
{
    public TaskListMemberRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<TaskListMember> GetMemberByUserIdAsync(string userId)
    {
        return await _context.TaskListMembers.FirstOrDefaultAsync(m => m.UserId == userId);
    }

    public async Task<int> GetCountAsync(string userId, string categoryName)
    {
        return await _context.TaskListMembers
            .Where(utl => utl.UserId == userId)
            .Join(_context.UserTaskListCategories,
                utl => utl.TaskListId,
                utc => utc.TaskListId,
                (utl, utc) => new { utl, utc })
            .Where(joined => joined.utc.Category.Name == categoryName)
            .CountAsync();
    }

    public async Task<string> GetAssignedRoleAsync(string userId, int taskListId)
    {
        var taskListUserRole = await _context.TaskListMembers
            .Where(tl => tl.TaskListId == taskListId && tl.UserId == userId)
            .FirstOrDefaultAsync();

        return taskListUserRole?.Role.ToString() ?? string.Empty;
    }

    public async Task<TaskListMember?> GetByCategoryIdAsync(string userId, int categoryId)
    {
        return await _context.TaskListMembers
            .Where(ut => ut.UserId == userId)
            .Join(_context.UserTaskListCategories,
                utl => utl.TaskListId,
                utc => utc.TaskListId,
                (utl, utc) => new { utl, utc })
            .FirstOrDefaultAsync(joined => joined.utc.CategoryId == categoryId)
            .ContinueWith(t => t.Result?.utl);
    }

    public async Task<TaskListMember?> GetByUserAndTaskListAsync(string userId, int taskListId)
    {
        return await _context.TaskListMembers
            .Where(ut => ut.UserId == userId && ut.TaskListId == taskListId)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> IsUserAMemberAsync(string userId, int taskListId)
    {
        return await _context.TaskListMembers.Where(q => q.UserId == userId && q.TaskListId == taskListId).AnyAsync();
    }
}