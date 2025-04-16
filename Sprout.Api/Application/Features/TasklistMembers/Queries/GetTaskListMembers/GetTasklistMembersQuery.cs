using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Domain.Enums;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Infrastructure;

namespace Sprout.Api.Application.Features.TasklistMembers.Queries.GetTasklistMembers;

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