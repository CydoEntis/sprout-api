using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetRecentCategories;

public record GetRecentCategoriesQuery() : IRequest<List<GetRecentCategoriesQueryResponse>>;

public class GetRecentCategoriesQueryResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Color { get; set; }
    public List<TasklistMetadata> RecentTasklists { get; set; } = new();
}

public class TasklistMetadata
{
    public int TasklistId { get; set; }
    public string TasklistName { get; set; }
}

public class GetRecentCategoriesQueryHandler : AuthRequiredHandler,
    IRequestHandler<GetRecentCategoriesQuery, List<GetRecentCategoriesQueryResponse>>
{
    private readonly AppDbContext _context;

    public GetRecentCategoriesQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        : base(httpContextAccessor)
    {
        _context = context;
    }

    public async Task<List<GetRecentCategoriesQueryResponse>> Handle(GetRecentCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        // Call the method to project data
        var categories = await GetRecentCategoriesWithTaskLists(userId, cancellationToken);

        return categories;
    }

    private async Task<List<GetRecentCategoriesQueryResponse>> GetRecentCategoriesWithTaskLists(string userId,
        CancellationToken cancellationToken)
    {
        var categories = await _context.Categories
            .Where(c => c.UserId == userId)
            .OrderByDescending(c => c.TaskLists.Max(t => t.UpdatedAt))
            .Take(5)
            .Select(c => new GetRecentCategoriesQueryResponse
            {
                Id = c.Id,
                Name = c.Name,
                Tag = c.Tag,
                Color = c.Color,
                RecentTasklists = _context.UserTaskListCategories
                    .Where(utc => utc.UserId == userId && utc.CategoryId == c.Id)
                    .OrderByDescending(t => t.UpdatedAt)
                    .Take(3)
                    .Select(s => new TasklistMetadata
                    {
                        TasklistId = s.TaskList.Id,
                        TasklistName = s.TaskList.Name,
                    })
                    .ToList()
            })
            .ToListAsync(cancellationToken);

        return categories;
    }
}