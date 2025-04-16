using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Api.Application.Shared.Handlers;
using Sprout.Api.Domain.Enums;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Application.Common.Exceptions;
using Sprout.Infrastructure;


namespace Sprout.Api.Application.Features.TasklistMembers.Commands.TransferOwnership;

public record TransferOwnershipCommand(int TaskListId, string NewOwnerId) : IRequest<TransferOwnershipCommandResponse>;

public class TransferOwnershipCommandResponse
{
    public string Message { get; set; } = "Ownership transferred successfully.";
}

public class TransferOwnershipCommandHandler
    : AuthRequiredHandler, IRequestHandler<TransferOwnershipCommand, TransferOwnershipCommandResponse>
{
    private readonly AppDbContext _context;

    public TransferOwnershipCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context)
        : base(httpContextAccessor)
    {
        _context = context;
    }

    public async Task<TransferOwnershipCommandResponse> Handle(TransferOwnershipCommand request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var requestingUser = await _context.TaskListMembers
            .FirstOrDefaultAsync(m => m.UserId == userId && m.TasklistId == request.TaskListId, cancellationToken);

        if (requestingUser == null || requestingUser.Role != TaskListRole.Owner)
            throw new PermissionException("You must be an owner to transfer ownership.");

        var newOwner = await _context.TaskListMembers
            .FirstOrDefaultAsync(m => m.UserId == request.NewOwnerId && m.TasklistId == request.TaskListId,
                cancellationToken);

        if (newOwner == null)
            throw new NotFoundException("New owner is not a member of this task list.");

        // Transfer ownership
        requestingUser.Role = TaskListRole.Editor;
        newOwner.Role = TaskListRole.Owner;

        await _context.SaveChangesAsync(cancellationToken);

        return new TransferOwnershipCommandResponse();
    }
}