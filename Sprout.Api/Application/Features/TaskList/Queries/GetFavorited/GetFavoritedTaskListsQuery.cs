using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Api.Application.Shared.Handlers;
using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Application.Shared.Projections;
using Sprout.Api.Infrastructure.Persistence;

namespace Sprout.Api.Application.Features.TaskList.Queries.GetFavorited
{
    public record GetFavoritedTaskListsQuery(
        int Page = 1,
        int PageSize = 1,
        string? Search = null,
        string SortBy = "createdAt",
        string SortDirection = "desc"
    ) : IRequest<PagedResponse<FavoritedTasklistQueryResponse>>;

    public class FavoritedTasklistQueryResponse
    {
        public int TaskListId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Member> Members { get; set; } = new();
        public int RemainingMembers { get; set; }
        public double TaskCompletionPercentage { get; set; }
        public bool IsFavorited { get; set; }
    }

    public class GetFavoritedTasklistsQueryHandler : AuthRequiredHandler,
        IRequestHandler<GetFavoritedTaskListsQuery, PagedResponse<FavoritedTasklistQueryResponse>>
    {
        private readonly AppDbContext _context;

        public GetFavoritedTasklistsQueryHandler(
            IHttpContextAccessor httpContextAccessor,
            AppDbContext context
        ) : base(httpContextAccessor)
        {
            _context = context;
        }

        public async Task<PagedResponse<FavoritedTasklistQueryResponse>> Handle(
            GetFavoritedTaskListsQuery request,
            CancellationToken cancellationToken
        )
        {
            var userId = GetAuthenticatedUserId();

            var query = _context.FavoriteTaskLists
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
                        })
                        .ToList(),
                    TotalTasks = f.TaskList.TaskListItems.Count,
                    CompletedTasks = f.TaskList.TaskListItems.Count(ti => ti.IsCompleted),
                    CategoryName = _context.UserTaskListCategories
                        .Where(utc => utc.UserId == userId && utc.TaskListId == f.TaskList.Id)
                        .Select(utc => utc.Category.Name)
                        .FirstOrDefault() ?? "Uncategorized"
                });

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var searchLower = request.Search.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(searchLower));
            }

            query = (request.SortBy.ToLower(), request.SortDirection.ToLower()) switch
            {
                ("name", "asc") => query.OrderBy(x => x.Name),
                ("name", "desc") => query.OrderByDescending(x => x.Name),
                ("createdat", "asc") => query.OrderBy(x => x.CreatedAt),
                ("createdat", "desc") => query.OrderByDescending(x => x.CreatedAt),
                ("updatedat", "asc") => query.OrderBy(x => x.UpdatedAt),
                ("updatedat", "desc") => query.OrderByDescending(x => x.UpdatedAt),
                _ => query.OrderByDescending(x => x.CreatedAt)
            };

            var totalCount = await query.CountAsync(cancellationToken);

            var data = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var result = data.Select(x =>
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
                    Name = x.Name,
                    Description = x.Description,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    Members = displayedMembers,
                    RemainingMembers = remainingCount,
                    TaskCompletionPercentage = x.TotalTasks > 0
                        ? Math.Round((x.CompletedTasks / (double)x.TotalTasks) * 100, 2)
                        : 0,
                    IsFavorited = true,
                    CategoryName = x.CategoryName
                };
            }).ToList();

            return new PagedResponse<FavoritedTasklistQueryResponse>(
                result,
                request.Page,
                request.PageSize,
                totalCount
            );
        }
    }
}