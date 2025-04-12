using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Enums;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TasklistMembers.Queries.GetTasklistMembers;

public record GetTasklistMembersQuery(int TaskListId) : IRequest<List<GetTasklistMembersQueryResponse>>;

public class GetTasklistMembersQueryResponse
{
    public string UserId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public TaskListRole Role { get; set; }
}

public class GetTasklistMembersQueryHandler
    : IRequestHandler<GetTasklistMembersQuery, List<GetTasklistMembersQueryResponse>>
{
    private readonly AppDbContext _context;

    public GetTasklistMembersQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetTasklistMembersQueryResponse>> Handle(
        GetTasklistMembersQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.TaskListMembers
            .Where(m => m.TasklistId == request.TaskListId)
            .Join(
                _context.Users,
                member => member.UserId,
                user => user.Id,
                (member, user) => new GetTasklistMembersQueryResponse
                {
                    UserId = user.Id,
                    Name = user.FirstName + " " + user.LastName,
                    Role = member.Role
                }
            )
            .ToListAsync(cancellationToken);
    }
}