using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Api.Application.Shared.Handlers;
using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Domain.Enums;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Application.Common.Exceptions;
using Sprout.Infrastructure;

namespace Sprout.Api.Application.Features.TasklistMembers.Commands.RemoveUserFromTasklist;

public record RemoveUserFromTasklistCommand(int TaskListId, string UserId)
    : IRequest<RemoveUserFromTasklistCommandResponse>;

public class RemoveUserFromTasklistCommandResponse : BaseResponse
{
    public string Message { get; set; } = "User removed from task list.";
}

public class RemoveUserCommandHandler
    : AuthRequiredHandler, IRequestHandler<RemoveUserFromTasklistCommand, RemoveUserFromTasklistCommandResponse>
{
    private readonly AppDbContext _context;

    public RemoveUserCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        : base(httpContextAccessor)
    {
        _context = context;
    }

    public async Task<RemoveUserFromTasklistCommandResponse> Handle(RemoveUserFromTasklistCommand request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var requestingUser = await _context.TaskListMembers
            .FirstOrDefaultAsync(m => m.UserId == userId && m.TasklistId == request.TaskListId, cancellationToken);

        if (requestingUser == null || requestingUser.Role == TaskListRole.Viewer)
            throw new PermissionException("You do not have permission to remove users.");

        var targetUser = await _context.TaskListMembers
            .FirstOrDefaultAsync(m => m.UserId == request.UserId && m.TasklistId == request.TaskListId,
                cancellationToken);

        if (targetUser == null)
            throw new NotFoundException("User is not a member of this task list.");

        _context.TaskListMembers.Remove(targetUser);

        var userCategory = await _context.UserTaskListCategories
            .Where(utc => utc.UserId == request.UserId && utc.TaskListId == request.TaskListId)
            .ToListAsync(cancellationToken);

        if (userCategory.Any())
        {
            _context.UserTaskListCategories.RemoveRange(userCategory);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return new RemoveUserFromTasklistCommandResponse();
    }
}