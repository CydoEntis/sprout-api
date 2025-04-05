using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Api.Domain.Enums;
using TaskGarden.Api.Infrastructure.Persistence;

namespace TaskGarden.Api.Application.Features.TaskList.Queries.GetFavorited;

public record GetFavoritedTaskListsQuery() : IRequest<List<FavoritedTasklistQueryResponse>>;

public class FavoritedTasklistQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CategoryName { get; set; }
    public List<Member> Members { get; set; } = new();
    public int TotalTasksCount { get; set; }
    public int CompletedTasksCount { get; set; }
    public double TaskCompletionPercentage { get; set; }
    public TaskListRole UserRole { get; set; }
}

public class GetFavoritedTasklistsQueryHandler : AuthRequiredHandler,
    IRequestHandler<GetFavoritedTaskListsQuery, List<FavoritedTasklistQueryResponse>>
{
    private readonly AppDbContext _context;

    public GetFavoritedTasklistsQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        : base(httpContextAccessor)
    {
        _context = context;
    }

    public async Task<List<FavoritedTasklistQueryResponse>> Handle(GetFavoritedTaskListsQuery request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var favoritedTasklists = await _context.FavoriteTaskLists
            .AsNoTracking()
            .Where(f => f.UserId == userId)
            .Select(f => new FavoritedTasklistQueryResponse
            {
                Id = f.TaskList.Id,
                Name = f.TaskList.Name,
                Description = f.TaskList.Description,
                CreatedAt = f.TaskList.CreatedAt,
                UpdatedAt = f.TaskList.UpdatedAt,
                CategoryName = _context.UserTaskListCategories
                    .Where(utc => utc.UserId == userId && utc.TaskListId == f.TaskList.Id)
                    .Select(utc => utc.Category.Name)
                    .FirstOrDefault() ?? "Uncategorized",
                Members = f.TaskList.TaskListMembers.Select(m => new Member
                {
                    UserId = m.UserId,
                    Name = m.User.LastName + " " + m.User.FirstName
                }).ToList(),
                TotalTasksCount = f.TaskList.TaskListItems.Count(),
                CompletedTasksCount = f.TaskList.TaskListItems.Count(ti => ti.IsCompleted),
                TaskCompletionPercentage = f.TaskList.TaskListItems.Any()
                    ? Math.Round((f.TaskList.TaskListItems.Count(ti => ti.IsCompleted) /
                                  (double)Math.Max(1, f.TaskList.TaskListItems.Count())) * 100, 2)
                    : 0,
                UserRole = f.TaskList.TaskListMembers
                    .Where(tlm => tlm.UserId == userId)
                    .Select(tlm => tlm.Role)
                    .FirstOrDefault()
            })
            .ToListAsync(cancellationToken);

        return favoritedTasklists;
    }
}