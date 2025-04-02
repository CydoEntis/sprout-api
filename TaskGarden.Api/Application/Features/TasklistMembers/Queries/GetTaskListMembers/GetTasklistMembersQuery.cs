using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TasklistMembers.Queries.GetTasklistMembers;

public record GetTasklistMembersQuery(int TaskListId) : IRequest<GetTasklistMembersQueryResponse>;

public class GetTasklistMembersQueryResponse : BaseResponse
{
    public List<TasklistMemberDto> Members { get; set; } = new();
}

public class TasklistMemberDto
{
    public string UserId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}

public class GetTasklistMembersQueryHandler
    : IRequestHandler<GetTasklistMembersQuery, GetTasklistMembersQueryResponse>
{
    private readonly AppDbContext _context;

    public GetTasklistMembersQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetTasklistMembersQueryResponse> Handle(GetTasklistMembersQuery request,
        CancellationToken cancellationToken)
    {
        var members = await _context.TasklistMembers
            .Where(m => m.TasklistId == request.TaskListId)
            .Join(
                _context.Users,
                member => member.UserId,
                user => user.Id,
                (member, user) => new TasklistMemberDto
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = member.Role.ToString()
                }
            )
            .ToListAsync(cancellationToken);

        return new GetTasklistMembersQueryResponse { Members = members };
    }
}