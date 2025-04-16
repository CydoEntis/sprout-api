using FluentValidation;
using MediatR;
using Sprout.Api.Application.Shared.Extensions;
using Sprout.Api.Application.Shared.Handlers;
using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Application.Common.Exceptions;
using Sprout.Infrastructure;

namespace Sprout.Api.Application.Features.TaskList.Commands.UpdateTaskList;

public record UpdateTaskListCommand(int TasklistId, string Name, string Description) : IRequest<UpdateTaskListResponse>;

public class UpdateTaskListResponse : BaseResponse
{
    public int TasklistId { get; set; }
}

public class UpdateTaskListCommandHandler : AuthRequiredHandler,
    IRequestHandler<UpdateTaskListCommand, UpdateTaskListResponse>
{
    private readonly AppDbContext _context;
    private readonly IValidator<UpdateTaskListCommand> _validator;

    public UpdateTaskListCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
        IValidator<UpdateTaskListCommand> validator) : base(httpContextAccessor)
    {
        _context = context;
        _validator = validator;
    }

    public async Task<UpdateTaskListResponse> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var hasAllowedRole = await _context.TaskListMembers.IsOwnerOrEditorAsync(userId, request.TasklistId);
        if (!hasAllowedRole)
            throw new PermissionException("User does not have the required role to update the task list.");

        var taskList = await _context.TaskLists.GetByIdAsync(request.TasklistId) ??
                       throw new NotFoundException($"Task list with id: {request.TasklistId} could not be found.");

        await UpdateTaskListAsync(taskList, request);

        return new UpdateTaskListResponse
        {
            Message = $"Task list with ID {taskList.Id} updated successfully",
            TasklistId = taskList.Id
        };
    }

    private async Task UpdateTaskListAsync(Domain.Entities.TaskList taskList, UpdateTaskListCommand request)
    {
        taskList.Name = request.Name?.Trim();
        taskList.Description = request.Description?.Trim();
        taskList.UpdatedAt = DateTime.UtcNow;

        _context.Update(taskList);
        await _context.SaveChangesAsync();
    }
}