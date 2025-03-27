using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;

public record GetRecentCategoriesQuery() : IRequest<List<GetRecentCategoriesQueryResponse>>;

public class GetRecentCategoriesQueryResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Color { get; set; }
    public List<TaskListInfo> RecentTaskLists { get; set; } = new();
}

public class TaskListInfo
{
    public int TaskListId { get; set; }
    public string TaskListName { get; set; }
}

public class CategoryWithTaskLists
{
    public Category Category { get; set; } = default!;
    public List<TaskListInfo> RecentlyUpdatedTaskLists { get; set; } = new();
}

public class GetRecentCategoriesQueryHandler : AuthRequiredHandler,
    IRequestHandler<GetRecentCategoriesQuery, List<GetRecentCategoriesQueryResponse>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetRecentCategoriesQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
        IMapper mapper)
        : base(httpContextAccessor)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetRecentCategoriesQueryResponse>> Handle(GetRecentCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();
        var categories = await GetCategoriesWithRecentTaskLists(userId);
        return _mapper.Map<List<GetRecentCategoriesQueryResponse>>(categories.Select(c =>
            new GetRecentCategoriesQueryResponse
            {
                Id = c.Category.Id,
                Name = c.Category.Name,
                Tag = c.Category.Tag,
                Color = c.Category.Color,
                RecentTaskLists = c.RecentlyUpdatedTaskLists
            }).ToList());
    }

    private async Task<List<CategoryWithTaskLists>> GetCategoriesWithRecentTaskLists(string userId)
    {
        var categories = await _context.Categories
            .Where(c => c.UserId == userId)
            .OrderByDescending(c => c.TaskLists.Max(t => t.UpdatedAt))
            .Take(5)
            .Select(c => new CategoryWithTaskLists
            {
                Category = c,
                RecentlyUpdatedTaskLists = _context.UserTaskListCategories
                    .Where(utc => utc.UserId == userId && utc.CategoryId == c.Id)
                    .OrderByDescending(t => t.UpdatedAt)
                    .Take(3)
                    .Select(s => new TaskListInfo
                    {
                        TaskListId = s.TaskList.Id,
                        TaskListName = s.TaskList.Name,
                    })
                    .ToList()
            })
            .ToListAsync();

        return categories;
    }
}