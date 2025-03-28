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

namespace TaskGarden.Api.Application.Features.TaskList.Queries.GetTaskListById;

public record GetTaskListByIdQuery(int TaskListId) : IRequest<GetTaskListByIdQueryResponse>;

public class GetTaskListByIdQueryResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CategoryDetails CategoryDetails { get; set; }
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

    public GetTaskListByIdQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context) :
        base(httpContextAccessor)
    {
        _context = context;
    }

    public async Task<GetTaskListByIdQueryResponse> Handle(GetTaskListByIdQuery request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        return await GetTaskListByIdAsync(request.TaskListId, cancellationToken) ??
               throw new NotFoundException("Task list could not be found.");
    }

    private async Task<GetTaskListByIdQueryResponse?> GetTaskListByIdAsync(int taskListId,
        CancellationToken cancellationToken)
    {
        return await _context.TaskLists
            .Include(tl => tl.UserCategories)
            .Include(tl => tl.TaskListMembers)
            .Include(tl => tl.TaskListItems)
            .Where(q => q.Id == taskListId)
            .Select(tl => new GetTaskListByIdQueryResponse()
            {
                Id = tl.Id,
                Name = tl.Name,
                Description = tl.Description,
                IsCompleted = tl.IsCompleted,
                CreatedAt = tl.CreatedAt,
                UpdatedAt = tl.UpdatedAt,
                CompletedTasksCount = tl.TaskListItems.Count(q => q.IsCompleted),
                TotalTasksCount = tl.TaskListItems.Count(),
                TaskListItems = tl.TaskListItems.OrderBy(q => q.Position).Select(q => new TaskListItemResponse
                {
                    Id = q.Id,
                    Description = q.Description,
                    IsCompleted = q.IsCompleted,
                    Position = q.Position,
                }).ToList(),
                CategoryDetails = tl.UserCategories
                    .Select(utc => new CategoryDetails
                    {
                        Id = utc.Category.Id,
                        Name = utc.Category.Name,
                        Tag = utc.Category.Tag,
                        Color = utc.Category.Color
                    })
                    .FirstOrDefault() ?? new CategoryDetails(),
                Members = tl.TaskListMembers
                    .Select(tla => new MemberResponse
                    {
                        UserId = tla.User.Id,
                        Name = tla.User.FirstName + " " + tla.User.LastName,
                    })
                    .ToList(),
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}