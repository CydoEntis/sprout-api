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

public record GetTasklistByIdQuery(int TaskListId) : IRequest<GetTaskListByIdQueryResponse>;

public class GetTaskListByIdQueryResponse
{
    public CategoryInfo CategoryInfo { get; set; }
    public TasklistInfo TasklistInfo { get; set; }
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

        return await GetTaskListByIdAsync(request.TaskListId, cancellationToken) ??
               throw new NotFoundException("Task list could not be found.");
    }

    private async Task<GetTaskListByIdQueryResponse?> GetTaskListByIdAsync(int taskListId,
        CancellationToken cancellationToken)
    {
        return await _context.TaskLists
            .AsNoTracking()
            .Where(q => q.Id == taskListId)
            .Select(tl => new GetTaskListByIdQueryResponse
            {
                CategoryInfo = tl.UserCategories
                    .Select(utc => new CategoryInfo
                    {
                        Id = utc.Category.Id,
                        Name = utc.Category.Name,
                        Tag = utc.Category.Tag,
                        Color = utc.Category.Color
                    })
                    .FirstOrDefault() ?? new CategoryInfo(),

                TasklistInfo = new TasklistInfo
                {
                    Id = tl.Id,
                    Name = tl.Name,
                    Description = tl.Description,
                    CreatedAt = tl.CreatedAt,
                    UpdatedAt = tl.UpdatedAt,
                    Members = tl.TaskListMembers
                        .Select(tlm => new Member
                        {
                            Id = tlm.User.Id,
                            Name = $"{tlm.User.LastName} {tlm.User.FirstName}"
                        })
                        .ToList(),
                    TotalTasksCount = tl.TaskListItems.Count(),
                    CompletedTasksCount = tl.TaskListItems.Count(ti => ti.IsCompleted),
                    TaskCompletionPercentage = tl.TaskListItems.Any()
                        ? Math.Round((tl.TaskListItems.Count(ti => ti.IsCompleted) /
                                      (double)Math.Max(1, tl.TaskListItems.Count())) * 100, 2)
                        : 0,
                    TaskListItems = tl.TaskListItems
                        .OrderBy(q => q.Position)
                        .Select(q => new TasklistItemDetail()
                        {
                            Id = q.Id,
                            Description = q.Description,
                            IsCompleted = q.IsCompleted,
                            Position = q.Position,
                        })
                        .ToList()
                }
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}