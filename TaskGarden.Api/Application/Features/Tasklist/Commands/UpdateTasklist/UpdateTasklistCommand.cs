using FluentValidation;
using MediatR;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskList.Commands.UpdateTaskList;

public record UpdateTasklistCommand(int TasklistId, string Name, string Description) : IRequest<UpdateTaskListResponse>;

public class UpdateTaskListResponse : BaseResponse
{
    public int TasklistId { get; set; }
}

public class UpdateTaskListCommandHandler : AuthRequiredHandler,
    IRequestHandler<UpdateTasklistCommand, UpdateTaskListResponse>
{
    private readonly AppDbContext _context;
    private readonly IValidator<UpdateTasklistCommand> _validator;

    public UpdateTaskListCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
        IValidator<UpdateTasklistCommand> validator) : base(httpContextAccessor)
    {
        _context = context;
        _validator = validator;
    }

    public async Task<UpdateTaskListResponse> Handle(UpdateTasklistCommand request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var hasAllowedRole = await _context.TasklistMembers.IsOwnerOrEditorAsync(userId, request.TasklistId);
        if (!hasAllowedRole)
            throw new PermissionException("User does not have the required role to update the task list.");

        var taskList = await _context.Tasklists.GetByIdAsync(request.TasklistId) ??
                       throw new NotFoundException($"Task list with id: {request.TasklistId} could not be found.");

        await UpdateTaskListAsync(taskList, request);

        return new UpdateTaskListResponse
        {
            Message = $"Task list with ID {taskList.Id} updated successfully",
            TasklistId = taskList.Id
        };
    }

    private async Task UpdateTaskListAsync(Domain.Entities.Tasklist tasklist, UpdateTasklistCommand request)
    {
        tasklist.Name = request.Name?.Trim();
        tasklist.Description = request.Description?.Trim();
        tasklist.UpdatedAt = DateTime.UtcNow;

        _context.Update(tasklist);
        await _context.SaveChangesAsync();
    }
}