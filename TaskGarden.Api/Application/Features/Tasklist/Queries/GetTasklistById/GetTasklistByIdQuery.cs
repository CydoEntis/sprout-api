using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Api.Application.Features.TaskList.Queries.GetTaskListById
{
    public record GetTasklistByIdQuery(int TaskListId) : IRequest<GetTaskListByIdQueryResponse>;

    public class GetTaskListByIdQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompletedTasksCount { get; set; }
        public int TotalTasksCount { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Member> Members { get; set; } = new List<Member>();
        public string CategoryColor { get; set; }
        public bool IsFavorited { get; set; }
    }

    public class GetTaskListByIdQueryHandler : AuthRequiredHandler,
        IRequestHandler<GetTasklistByIdQuery, GetTaskListByIdQueryResponse>
    {
        private readonly AppDbContext _context;

        public GetTaskListByIdQueryHandler(HttpContextAccessor httpContextAccessor, AppDbContext context) : base(
            httpContextAccessor)
        {
            _context = context;
        }

        public async Task<GetTaskListByIdQueryResponse> Handle(GetTasklistByIdQuery request,
            CancellationToken cancellationToken)
        {
            var userId = GetAuthenticatedUserId();
            var taskListResponse = await GetTaskListByIdAsync(request.TaskListId, userId, cancellationToken);
            if (taskListResponse == null)
                throw new NotFoundException("Task list could not be found.");

            return taskListResponse;
        }

        private async Task<GetTaskListByIdQueryResponse?> GetTaskListByIdAsync(int taskListId, string userId,
            CancellationToken cancellationToken)
        {
            var taskListData = await _context.UserTasklistCategories
                .AsNoTracking()
                .Where(utc => utc.TaskListId == taskListId)
                .Include(utc => utc.Tasklist)
                .Include(utc => utc.Category)
                .Select(utc => new GetTaskListByIdQueryResponse
                {
                    Id = utc.Tasklist.Id,
                    Name = utc.Tasklist.Name,
                    Description = utc.Tasklist.Description,
                    CreatedAt = utc.Tasklist.CreatedAt,
                    UpdatedAt = utc.Tasklist.UpdatedAt,
                    Members = utc.Tasklist.TaskListMembers
                        .Select(tlm => new Member
                        {
                            Id = tlm.User.Id,
                            Name = $"{tlm.User.LastName} {tlm.User.FirstName}"
                        })
                        .ToList(),
                    TotalTasksCount = utc.Tasklist.TaskListItems.Count(),
                    CompletedTasksCount = utc.Tasklist.TaskListItems.Count(ti => ti.IsCompleted),
                    CategoryColor = utc.Category.Color,
                    IsFavorited = _context.FavoriteTasklists
                        .Any(f => f.UserId == userId &&
                                  f.TaskListId == utc.Tasklist.Id) // Check if the task list is favorited
                })
                .FirstOrDefaultAsync(cancellationToken);

            return taskListData;
        }
    }
}