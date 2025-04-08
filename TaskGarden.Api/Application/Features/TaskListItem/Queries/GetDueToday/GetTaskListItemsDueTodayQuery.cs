using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Infrastructure.Persistence;

namespace TaskGarden.Api.Application.Features.TaskListItem.Queries.GetDueToday;

public record GetTaskListItemsDueTodayQuery(int TaskListId, int Page, int PageSize)
    : IRequest<PagedResponse<TodaysTaskListItem>>;

public class TodaysTaskListItem
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public int TaskListId { get; set; }
    public string CategoryName { get; set; } = null!;
    public string CategoryColor { get; set; } = null!;
    public string CategoryTag { get; set; } = null!;
    public string TaskListName { get; set; } = null!;
}

public class GetTaskListItemsDueTodayQueryHandler : AuthRequiredHandler,
    IRequestHandler<GetTaskListItemsDueTodayQuery, PagedResponse<TodaysTaskListItem>>
{
    private readonly AppDbContext _context;

    public GetTaskListItemsDueTodayQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        : base(httpContextAccessor)
    {
        _context = context;
    }

    public async Task<PagedResponse<TodaysTaskListItem>> Handle(
        GetTaskListItemsDueTodayQuery request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();
        var today = DateTime.UtcNow.Date;

        var query = _context.TaskListItems
            .AsNoTracking()
            .Where(ti =>
                ti.TasklistId == request.TaskListId &&
                ti.DueDate.HasValue &&
                ti.DueDate.Value.Date == today &&
                ti.TaskList.TaskListMembers.Any(m => m.UserId == userId))
            .Select(ti => new TodaysTaskListItem
            {
                Id = ti.Id,
                Description = ti.Description,
                DueDate = ti.DueDate ?? today,
                IsCompleted = ti.IsCompleted,
                TaskListId = ti.TasklistId,
                TaskListName = ti.TaskList.Name,
                CategoryName = ti.TaskList.UserCategories
                    .Where(c => c.UserId == userId)
                    .Select(c => c.Category.Name)
                    .First()!,
                CategoryColor = ti.TaskList.UserCategories
                    .Where(c => c.UserId == userId)
                    .Select(c => c.Category.Color)
                    .First()!,
                CategoryTag = ti.TaskList.UserCategories
                    .Where(c => c.UserId == userId)
                    .Select(c => c.Category.Tag)
                    .First()!
            });

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(t => t.Id)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new PagedResponse<TodaysTaskListItem>(items, request.Page, request.PageSize, totalCount);
    }
}