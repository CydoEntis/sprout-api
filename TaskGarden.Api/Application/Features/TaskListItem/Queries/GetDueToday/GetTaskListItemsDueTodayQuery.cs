using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Infrastructure.Persistence;

namespace TaskGarden.Api.Application.Features.TaskListItem.Queries.GetDueToday;

public record GetTaskListItemsDueTodayQuery()
    : IRequest<List<TodaysTaskListItemGroup>>;

public class TodaysTaskListItem
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public int TaskListId { get; set; }
    public string TaskListName { get; set; } = null!;
}

public class TodaysTaskListItemGroup
{
    public string CategoryName { get; set; } = null!;
    public string CategoryColor { get; set; } = null!;
    public string CategoryTag { get; set; } = null!;
    public List<TodaysTaskListItem> Items { get; set; } = new();
}

public class GetTaskListItemsDueTodayQueryHandler : AuthRequiredHandler,
    IRequestHandler<GetTaskListItemsDueTodayQuery, List<TodaysTaskListItemGroup>>
{
    private readonly AppDbContext _context;

    public GetTaskListItemsDueTodayQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        : base(httpContextAccessor)
    {
        _context = context;
    }

    public async Task<List<TodaysTaskListItemGroup>> Handle(
        GetTaskListItemsDueTodayQuery request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();
        var today = DateTime.UtcNow.Date;

        var items = await _context.TaskListItems
            .AsNoTracking()
            .Where(ti =>
                ti.DueDate.HasValue &&
                ti.DueDate.Value.Date == today &&
                ti.TaskList.TaskListMembers.Any(m => m.UserId == userId))
            .Select(ti => new
            {
                ti.Id,
                ti.Description,
                DueDate = ti.DueDate ?? today,
                ti.IsCompleted,
                ti.TasklistId,
                TaskListName = ti.TaskList.Name,
                Category = ti.TaskList.UserCategories
                    .Where(c => c.UserId == userId)
                    .Select(c => new
                    {
                        c.Category.Name,
                        c.Category.Color,
                        c.Category.Tag
                    }).FirstOrDefault()
            })
            .ToListAsync(cancellationToken);

        var grouped = items
            .Where(i => i.Category != null)
            .GroupBy(i => new { i.Category!.Name, i.Category.Color, i.Category.Tag })
            .Select(g => new TodaysTaskListItemGroup
            {
                CategoryName = g.Key.Name,
                CategoryColor = g.Key.Color,
                CategoryTag = g.Key.Tag,
                Items = g.Select(i => new TodaysTaskListItem
                {
                    Id = i.Id,
                    Description = i.Description,
                    DueDate = i.DueDate,
                    IsCompleted = i.IsCompleted,
                    TaskListId = i.TasklistId,
                    TaskListName = i.TaskListName
                }).ToList()
            })
            .ToList();

        return grouped;
    }
}