using AutoMapper;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.TaskList.Queries.GetTaskListById;

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

public class GetTaskListByIdQueryHandler(
    IUserContextService userContextService,
    ITaskListRepository taskListRepository,
    IMapper mapper)
    : IRequestHandler<GetTaskListByIdQuery, GetTaskListByIdQueryResponse>
{
    public async Task<GetTaskListByIdQueryResponse> Handle(GetTaskListByIdQuery request,
        CancellationToken cancellationToken)
    {
        var userId = userContextService.GetAuthenticatedUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var taskLists = await taskListRepository.GetDetailsByIdAsync(request.TaskListId);
        return mapper.Map<GetTaskListByIdQueryResponse>(taskLists);
    }
}