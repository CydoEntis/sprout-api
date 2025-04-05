using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Api.Domain.Enums;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskList.Queries.GetTaskListById
{
    public record GetTaskListByIdQuery(int TaskListId) : IRequest<GetTaskListByIdQueryResponse>;

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
        public int AdditionalMemberCount { get; set; }
        public string CategoryColor { get; set; }
        public bool IsFavorited { get; set; }
        public TaskListRole Role { get; set; }
    }

    public class GetTaskListByIdQueryHandler : AuthRequiredHandler,
        IRequestHandler<GetTaskListByIdQuery, GetTaskListByIdQueryResponse>
    {
        private readonly AppDbContext _context;

        public GetTaskListByIdQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context) : base(
            httpContextAccessor)
        {
            _context = context;
        }

        public async Task<GetTaskListByIdQueryResponse> Handle(GetTaskListByIdQuery request,
            CancellationToken cancellationToken)
        {
            var userId = GetAuthenticatedUserId();
            var taskListResponse = await GetTaskListByIdAsync(request.TaskListId, userId, cancellationToken);
            if (taskListResponse == null)
                throw new NotFoundException("Task list could not be found.");

            return taskListResponse;
        }

        private async Task<GetTaskListByIdQueryResponse?> GetTaskListByIdAsync(
            int taskListId,
            string userId,
            CancellationToken cancellationToken)
        {
            var taskListData = await _context.UserTaskListCategories
                .AsNoTracking()
                .Where(utc => utc.TaskListId == taskListId)
                .Include(utc => utc.TaskList)
                .ThenInclude(tl => tl.TaskListMembers)
                .ThenInclude(tlm => tlm.User)
                .Include(utc => utc.Category)
                .FirstOrDefaultAsync(cancellationToken);

            if (taskListData == null)
                return null;

            var taskList = taskListData.TaskList;

            // Get first 5 members and count of remaining
            var allMembers = taskList.TaskListMembers
                .Where(tlm => tlm.User != null)
                .ToList();

            var members = allMembers
                .Take(5)
                .Select(tlm => new Member
                {
                    UserId = tlm.User.Id,
                    Name = $"{tlm.User.FirstName} {tlm.User.LastName}"
                })
                .ToList();

            var additionalMemberCount = Math.Max(0, allMembers.Count - 5);

            // Get task counts via optimized queries
            var totalTasksCount = await _context.TaskListItems
                .Where(ti => ti.TasklistId == taskListId)
                .CountAsync(cancellationToken);

            var completedTasksCount = await _context.TaskListItems
                .Where(ti => ti.TasklistId == taskListId && ti.IsCompleted)
                .CountAsync(cancellationToken);

            var isFavorited = await _context.FavoriteTaskLists
                .AnyAsync(f => f.UserId == userId && f.TaskListId == taskList.Id, cancellationToken);

            var role = taskList.TaskListMembers
                .Where(m => m.UserId == userId)
                .Select(m => m.Role)
                .FirstOrDefault();

            return new GetTaskListByIdQueryResponse
            {
                Id = taskList.Id,
                Name = taskList.Name,
                Description = taskList.Description,
                CreatedAt = taskList.CreatedAt,
                UpdatedAt = taskList.UpdatedAt,
                Members = members,
                AdditionalMemberCount = additionalMemberCount,
                TotalTasksCount = totalTasksCount,
                CompletedTasksCount = completedTasksCount,
                CategoryColor = taskListData.Category.Color,
                IsFavorited = isFavorited,
                Role = role
            };
        }
    }
}