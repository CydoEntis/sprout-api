using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Api.Application.Shared.Handlers;
using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Infrastructure.Persistence;

namespace Sprout.Api.Application.Features.TaskListItem.Queries.GetDueForTheWeek;

public record GetTaskListItemsDueForTheWeekPerCategoryQuery(
    int Page = 1,
    int PageSize = 10,
    string? Search = null,
    string SortBy = "dueDate",
    string SortDirection = "asc",
    bool? IsCompleted = null
) : IRequest<PagedResponse<TaskListItemCategoryGroup>>;

public class TaskListItemDue
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public int TaskListId { get; set; }
    public string TaskListName { get; set; } = null!;
}

public class TaskListCategoryGroup
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public string CategoryColor { get; set; } = null!;
    public string CategoryTag { get; set; } = null!;
    public List<TaskListItemDue> Items { get; set; } = new();
    public int DueCount { get; set; }
}

public class TaskListItemCategoryGroup
{
    public DateTime Date { get; set; }
    public List<TaskListCategoryGroup> Categories { get; set; } = new();
}

public class GetTaskListItemsDueForTheWeekPerCategoryQueryHandler : AuthRequiredHandler,
    IRequestHandler<GetTaskListItemsDueForTheWeekPerCategoryQuery, PagedResponse<TaskListItemCategoryGroup>>
{
    private readonly AppDbContext _context;

    public GetTaskListItemsDueForTheWeekPerCategoryQueryHandler(
        IHttpContextAccessor httpContextAccessor,
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
                ti.DueDate.Value.Date >= startDate &&
                ti.DueDate.Value.Date < endDate &&
                ti.TaskList.TaskListMembers.Any(m => m.UserId == userId));

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var searchLower = request.Search.ToLower();
            query = query.Where(ti =>
                (ti.Description != null && ti.Description.ToLower().Contains(searchLower)) ||
                ti.TaskList.Name.ToLower().Contains(searchLower));
        }

        if (request.IsCompleted.HasValue)
        {
            query = query.Where(ti => ti.IsCompleted == request.IsCompleted.Value);
        }

        query = (request.SortBy.ToLower(), request.SortDirection.ToLower()) switch
        {
            ("description", "asc") => query.OrderBy(ti => ti.Description),
            ("description", "desc") => query.OrderByDescending(ti => ti.Description),
            ("duedate", "asc") => query.OrderBy(ti => ti.DueDate),
            ("duedate", "desc") => query.OrderByDescending(ti => ti.DueDate),
            ("completed", "asc") => query.OrderBy(ti => ti.IsCompleted),
            ("completed", "desc") => query.OrderByDescending(ti => ti.IsCompleted),
            _ => query.OrderBy(ti => ti.DueDate)
        };

        var totalCount = await query.CountAsync(cancellationToken);

        var pagedItems = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
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
            })
            .ToListAsync(cancellationToken);

        var grouped = pagedItems
            .Where(i => i.Category != null)
            .GroupBy(i => i.DueDate.Date)
            .Select(dateGroup => new TaskListItemCategoryGroup
            {
                Date = dateGroup.Key,
                Categories = dateGroup
                    .GroupBy(i => new
                    {
                        i.Category!.Id,
                        i.Category.Name,
                        i.Category.Color,
                        i.Category.Tag
                    })
                    .Select(catGroup => new TaskListCategoryGroup
                    {
                        CategoryId = catGroup.Key.Id,
                        CategoryName = catGroup.Key.Name,
                        CategoryColor = catGroup.Key.Color,
                        CategoryTag = catGroup.Key.Tag,
                        Items = catGroup.Select(i => new TaskListItemDue
                        {
                            Id = i.Id,
                            Description = i.Description,
                            DueDate = i.DueDate,
                            IsCompleted = i.IsCompleted,
                            TaskListId = i.TasklistId,
                            TaskListName = i.TaskListName
                        }).ToList(),
                        DueCount = catGroup.Count()
                    }).ToList()
            })
            .OrderBy(g => g.Date)
            .ToList();

        return new PagedResponse<TaskListItemCategoryGroup>(grouped, request.Page, request.PageSize, totalCount);
    }
}
