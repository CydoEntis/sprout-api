using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Api.Application.Shared.Extensions;
using Sprout.Api.Application.Shared.Handlers;
using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Application.Common.Exceptions;
using Sprout.Domain.Enums;
using Sprout.Infrastructure;

namespace Sprout.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItemCompletedStatus;

public record UpdateTaskListItemCompletedStatusCommand(int Id, bool IsCompleted)
    : IRequest<UpdateTaskListItemCompletedStatusResponse>;

public class UpdateTaskListItemCompletedStatusResponse : BaseResponse
{
    public int TaskListItemId { get; set; }
}

public class UpdateTaskListItemCompletedStatusCommandHandler : AuthRequiredHandler,
    IRequestHandler<UpdateTaskListItemCompletedStatusCommand, UpdateTaskListItemCompletedStatusResponse>
{
    private readonly AppDbContext _context;
    private readonly IValidator<UpdateTaskListItemCompletedStatusCommand> _validator;

    public UpdateTaskListItemCompletedStatusCommandHandler(
        IHttpContextAccessor httpContextAccessor,
        AppDbContext context,
        IValidator<UpdateTaskListItemCompletedStatusCommand> validator)
        : base(httpContextAccessor)
    {
        _context = context;
        _validator = validator;
    }

    public async Task<UpdateTaskListItemCompletedStatusResponse> Handle(
        UpdateTaskListItemCompletedStatusCommand request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var taskListItem = await _context.TaskListItems.GetByIdAsync(request.Id);
        if (taskListItem == null)
            throw new NotFoundException($"Task List Item with id: {request.Id} not found");

        var userHasRole = await _context.TaskListMembers.IsOwnerOrEditorAsync(userId, taskListItem.TasklistId);
        if (!userHasRole)
            throw new PermissionException("User doesn't have role to update item.");

        taskListItem.IsCompleted = request.IsCompleted;
        taskListItem.CompletedById = request.IsCompleted ? userId : null;

        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateTaskListItemCompletedStatusResponse
        {
            Message = $"Task list item with id {taskListItem.Id} status updated",
            TaskListItemId = taskListItem.Id
        };
    }
}