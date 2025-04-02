using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Enums;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TasklistMembers.Commands.RemoveUserFromTasklist;

public record RemoveUserFromTasklistCommand(int TaskListId, string TargetUserId)
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

        var requestingUser = await _context.TasklistMembers
            .FirstOrDefaultAsync(m => m.UserId == userId && m.TasklistId == request.TaskListId, cancellationToken);

        if (requestingUser == null || requestingUser.Role == TaskListRole.Viewer)
            throw new PermissionException("You do not have permission to remove users.");

        var targetUser = await _context.TasklistMembers
            .FirstOrDefaultAsync(m => m.UserId == request.TargetUserId && m.TasklistId == request.TaskListId,
                cancellationToken);

        if (targetUser == null)
            throw new NotFoundException("User is not a member of this task list.");

        _context.TasklistMembers.Remove(targetUser);

        var userCategory = await _context.UserTasklistCategories
            .Where(utc => utc.UserId == request.TargetUserId && utc.TaskListId == request.TaskListId)
            .ToListAsync(cancellationToken);

        if (userCategory.Any())
        {
            _context.UserTasklistCategories.RemoveRange(userCategory);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return new RemoveUserFromTasklistCommandResponse();
    }
}