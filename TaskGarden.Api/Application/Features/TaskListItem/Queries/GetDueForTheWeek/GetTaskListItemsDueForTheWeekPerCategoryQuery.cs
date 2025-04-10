using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Infrastructure.Persistence;

namespace TaskGarden.Api.Application.Features.TaskListItem.Queries.GetDueForTheWeek;

public record GetTaskListItemsDueForTheWeekPerCategoryQuery(int Page, int PageSize)
    : IRequest<PagedResponse<TaskListItemCategoryGroup>>;

public class TaskListItemDue
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public int TaskListId { get; set; }
    public string TaskListName { get; set; } = null!;
}

public class TaskListItemCategoryGroup
{
    public DateTime Date { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public string CategoryColor { get; set; } = null!;
    public string CategoryTag { get; set; } = null!;
    public List<TaskListItemDue> Items { get; set; } = new();
    public int DueCount { get; set; }
}

public class GetTaskListItemsDueForTheWeekPerCategoryQueryHandler : AuthRequiredHandler,
    IRequestHandler<GetTaskListItemsDueForTheWeekPerCategoryQuery, PagedResponse<TaskListItemCategoryGroup>>
{
    private readonly AppDbContext _context;

    public GetTaskListItemsDueForTheWeekPerCategoryQueryHandler(IHttpContextAccessor httpContextAccessor,
        AppDbContext context)
        : base(httpContextAccessor)
    {
        _context = context;
    }

    public async Task<PagedResponse<TaskListItemCategoryGroup>> Handle(
        GetTaskListItemsDueForTheWeekPerCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var startDate = DateTime.UtcNow.Date.AddDays(1); 
        var endDate = startDate.AddDays(7); 

        var query = _context.TaskListItems
            .AsNoTracking()
            .Where(ti =>
                ti.DueDate.HasValue &&
                ti.DueDate.Value.Date >= startDate && ti.DueDate.Value.Date < endDate &&
                ti.TaskList.TaskListMembers.Any(m => m.UserId == userId))
            .Select(ti => new
            {
                ti.Id,
                ti.Description,
                DueDate = ti.DueDate ?? startDate,
                ti.IsCompleted,
                ti.TasklistId,
                TaskListName = ti.TaskList.Name,
                Category = ti.TaskList.UserCategories
                    .Where(c => c.UserId == userId)
                    .Select(c => new
                    {
                        c.Category.Id,
                        c.Category.Name,
                        c.Category.Color,
                        c.Category.Tag
                    }).FirstOrDefault()
            });

        var totalCount = await query.CountAsync(cancellationToken);

        var pagedItems = await query
            .OrderBy(i => i.DueDate)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var grouped = pagedItems
            .Where(i => i.Category != null)
            .GroupBy(i => new
            {
                i.DueDate.Date, i.Category!.Id, i.Category.Name, i.Category.Color, i.Category.Tag
            }) 
            .Select(g => new TaskListItemCategoryGroup
            {
                Date = g.Key.Date,
                CategoryId = g.Key.Id,
                CategoryName = g.Key.Name,
                CategoryColor = g.Key.Color,
                CategoryTag = g.Key.Tag,
                Items = g.Select(i => new TaskListItemDue
                {
                    Id = i.Id,
                    Description = i.Description,
                    DueDate = i.DueDate,
                    IsCompleted = i.IsCompleted,
                    TaskListId = i.TasklistId,
                    TaskListName = i.TaskListName
                }).ToList(),
                DueCount = g.Count()
            })
            .ToList();

        return new PagedResponse<TaskListItemCategoryGroup>(grouped, request.Page, request.PageSize, totalCount);
    }
}