using MediatR;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TasklistMembers.Commands.UpdateUserRole;

public record UpdateUserRoleCommand(int TaskListId, string TargetUserId, TaskListRole NewRole)
    : IRequest<UpdateUserRoleCommandResponse>;

public class UpdateUserRoleCommandResponse : BaseResponse
{
    public string Message { get; set; } = "User role updated successfully.";
}

public class UpdateUserRoleCommandHandler
    : AuthRequiredHandler, IRequestHandler<UpdateUserRoleCommand, UpdateUserRoleCommandResponse>
{
    private readonly AppDbContext _context;

    public UpdateUserRoleCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        : base(httpContextAccessor)
    {
        _context = context;
    }

    public async Task<UpdateUserRoleCommandResponse> Handle(UpdateUserRoleCommand request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var requestingUser = await _context.TasklistMembers
            .FirstOrDefaultAsync(m => m.UserId == userId && m.TasklistId == request.TaskListId, cancellationToken);

        if (requestingUser == null || requestingUser.Role == TaskListRole.Viewer)
            throw new PermissionException("You do not have permission to update roles.");

        var targetUser = await _context.TasklistMembers
            .FirstOrDefaultAsync(m => m.UserId == request.TargetUserId && m.TasklistId == request.TaskListId,
                cancellationToken);

        if (targetUser == null)
            throw new NotFoundException("User is not a member of this task list.");

        targetUser.Role = request.NewRole;
        _context.TasklistMembers.Update(targetUser);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateUserRoleCommandResponse();
    }
}