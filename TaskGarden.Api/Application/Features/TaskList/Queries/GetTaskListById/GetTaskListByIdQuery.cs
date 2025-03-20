using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Api.Application.Features.TaskList.Queries.GetTaskListById;

public record GetTaskListByIdQuery(int TaskListId) : IRequest<GetTaskListByIdQueryResponse>;

public class GetTaskListByIdQueryResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public bool IsCompleted { get; set; }
    public List<MemberResponse> Members { get; set; } = [];
    public int TotalTasksCount { get; set; }
    public int CompletedTasksCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<TaskListItemResponse> TaskListItems { get; set; } = [];
}

public class GetTaskListByIdQueryHandler
    : AuthRequiredHandler, IRequestHandler<GetTaskListByIdQuery, GetTaskListByIdQueryResponse>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetTaskListByIdQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context, IMapper mapper) :
        base(httpContextAccessor)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetTaskListByIdQueryResponse> Handle(GetTaskListByIdQuery request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var taskList = await GetTaskListByIdAsync(request.TaskListId) ??
                       throw new NotFoundException("Task list could not be found.");

        return _mapper.Map<GetTaskListByIdQueryResponse>(taskList);
    }

    private async Task<TaskListPreview?> GetTaskListByIdAsync(int taskListId)
    {
        return await _context.TaskLists
            .Include(tl => tl.UserCategories)
            .Include(tl => tl.TaskListMembers)
            .Where(q => q.Id == taskListId)
            .Select(tl => new TaskListPreview()
            {
                Id = tl.Id,
                Name = tl.Name,
                Description = tl.Description,
                CategoryName = tl.UserCategories
                    .Select(utc => utc.Category.Name)
                    .FirstOrDefault() ?? "No Category",
                CompletedTasksCount = tl.TaskListItems.Count(q => q.IsCompleted),
                TotalTasksCount = tl.TaskListItems.Count(),
                IsCompleted = tl.IsCompleted,
                CreatedAt = tl.CreatedAt,
                Members = tl.TaskListMembers
                    .Select(tla => new Member
                    {
                        Id = tla.User.Id,
                        Name = tla.User.FirstName + " " + tla.User.LastName,
                    })
                    .ToList(),
                TaskListItems = tl.TaskListItems.OrderBy(q => q.Position).Select(q => new TaskListItemDetail
                {
                    Id = q.Id,
                    Description = q.Description,
                    IsCompleted = q.IsCompleted,
                    Position = q.Position,
                }).ToList(),
            })
            .FirstOrDefaultAsync();
    }
}