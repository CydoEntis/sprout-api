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
    public int TaskListId { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Member> Members { get; set; } = new List<Member>();
    public int RemainingMembers { get; set; }
    public double TaskCompletionPercentage { get; set; }
    public bool IsFavorited { get; set; }
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
            .Select(f => new
            {
                f.TaskList.Id,
                f.TaskList.Name,
                f.TaskList.Description,
                f.TaskList.CreatedAt,
                f.TaskList.UpdatedAt,
                Members = f.TaskList.TaskListMembers
                    .OrderBy(m => m.User.LastName)
                    .ThenBy(m => m.User.FirstName)
                    .Select(m => new
                    {
                        m.UserId,
                        Name = m.User.LastName + " " + m.User.FirstName
                    }).ToList(),
                TotalTasks = f.TaskList.TaskListItems.Count,
                CompletedTasks = f.TaskList.TaskListItems.Count(ti => ti.IsCompleted),
                CategoryName = _context.UserTaskListCategories
                    .Where(utc => utc.UserId == userId && utc.TaskListId == f.TaskList.Id)
                    .Select(utc => utc.Category.Name)
                    .FirstOrDefault() ?? "Uncategorized"
            })
            .ToListAsync(cancellationToken);

        var response = favoritedTasklists.Select(x =>
        {
            var displayedMembers = x.Members.Take(5)
                .Select(m => new Member
                {
                    UserId = m.UserId,
                    Name = m.Name
                }).ToList();

            var remainingCount = x.Members.Count > 5 ? x.Members.Count - 5 : 0;

            return new FavoritedTasklistQueryResponse
            {
                TaskListId = x.Id,
                CategoryName = x.CategoryName,
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                Members = displayedMembers,
                RemainingMembers = remainingCount,
                TaskCompletionPercentage = x.TotalTasks > 0
                    ? Math.Round((x.CompletedTasks / (double)x.TotalTasks) * 100, 2)
                    : 0,
                IsFavorited = true
            };
        }).ToList();

        return response;
    }
}