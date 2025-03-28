using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
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
        public string Tag { get; set; }
        public string Color { get; set; }
        public TasklistInfo Tasklist { get; set; }
    }

    public class GetTaskListByIdQueryHandler
        : AuthRequiredHandler, IRequestHandler<GetTasklistByIdQuery, GetTaskListByIdQueryResponse>
    {
        private readonly AppDbContext _context;

        public GetTaskListByIdQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context) :
            base(httpContextAccessor)
        {
            _context = context;
        }

        public async Task<GetTaskListByIdQueryResponse> Handle(GetTasklistByIdQuery request,
            CancellationToken cancellationToken)
        {
            var userId = GetAuthenticatedUserId();

            var taskListResponse = await GetTaskListByIdAsync(request.TaskListId, cancellationToken);
            if (taskListResponse == null)
                throw new NotFoundException("Task list could not be found.");

            return taskListResponse;
        }

        private async Task<GetTaskListByIdQueryResponse?> GetTaskListByIdAsync(int taskListId,
            CancellationToken cancellationToken)
        {
            var taskListData = await _context.UserTasklistCategories
                .AsNoTracking()
                .Where(utc => utc.TaskListId == taskListId)
                .Select(utc => new GetTaskListByIdQueryResponse
                {
                    Tasklist = new TasklistInfo
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
                        TaskCompletionPercentage = utc.Tasklist.TaskListItems.Any()
                            ? Math.Round((utc.Tasklist.TaskListItems.Count(ti => ti.IsCompleted) /
                                          (double)Math.Max(1, utc.Tasklist.TaskListItems.Count())) * 100, 2)
                            : 0,
                        TaskListItems = utc.Tasklist.TaskListItems
                            .OrderBy(q => q.Position)
                            .Select(q => new TasklistItemDetail
                            {
                                Id = q.Id,
                                Description = q.Description,
                                IsCompleted = q.IsCompleted,
                                Position = q.Position,
                            })
                            .ToList()
                    },
                    // Accessing Category details directly from UserTasklistCategory
                    Id = utc.Category.Id,
                    Name = utc.Category.Name,
                    Tag = utc.Category.Tag,
                    Color = utc.Category.Color
                })
                .FirstOrDefaultAsync(cancellationToken);

            return taskListData;
        }
    }
}