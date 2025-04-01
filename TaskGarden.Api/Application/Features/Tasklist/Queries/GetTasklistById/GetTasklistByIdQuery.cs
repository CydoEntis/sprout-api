using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Api.Domain.Enums;
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
        public TaskListRole Role { get; set; }
    }

    public class GetTaskListByIdQueryHandler : AuthRequiredHandler,
        IRequestHandler<GetTasklistByIdQuery, GetTaskListByIdQueryResponse>
    {
        private readonly AppDbContext _context;

        public GetTaskListByIdQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context) : base(
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
                .ThenInclude(tl => tl.TaskListMembers)
                .ThenInclude(tlm => tlm.User)
                .Include(utc => utc.Tasklist)
                .ThenInclude(tl => tl.TaskListItems)
                .Include(utc => utc.Category)
                .FirstOrDefaultAsync(cancellationToken);

            if (taskListData == null)
                return null;

            return new GetTaskListByIdQueryResponse
            {
                Id = taskListData.Tasklist.Id,
                Name = taskListData.Tasklist.Name,
                Description = taskListData.Tasklist.Description,
                CreatedAt = taskListData.Tasklist.CreatedAt,
                UpdatedAt = taskListData.Tasklist.UpdatedAt,
                Members = taskListData.Tasklist.TaskListMembers
                    .Where(tlm => tlm.User != null) // ✅ Ensure user is not null
                    .Select(tlm => new Member
                    {
                        Id = tlm.User.Id,
                        Name = $"{tlm.User.FirstName} {tlm.User.LastName}"
                    })
                    .ToList(),
                TotalTasksCount = taskListData.Tasklist.TaskListItems.Count(),
                CompletedTasksCount = taskListData.Tasklist.TaskListItems.Count(ti => ti.IsCompleted),
                CategoryColor = taskListData.Category.Color,
                IsFavorited = await _context.FavoriteTasklists
                    .AnyAsync(f => f.UserId == userId && f.TaskListId == taskListData.Tasklist.Id, cancellationToken),
                Role = taskListData.Tasklist.TaskListMembers
                    .Where(m => m.UserId == userId)
                    .Select(m => m.Role)
                    .FirstOrDefault()
            };
        }
    }
}