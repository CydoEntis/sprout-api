using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.TaskList.Commands.UpdateTaskList;

public record UpdateTaskListCommand(int TaskListId, string Name, string Description) : IRequest<UpdateTaskListResponse>;

public class UpdateTaskListResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class UpdateTaskListCommandHandler : AuthRequiredHandler,
    IRequestHandler<UpdateTaskListCommand, UpdateTaskListResponse>
{
    private readonly AppDbContext _context;
    private readonly IValidator<UpdateTaskListCommand> _validator;
    private readonly IMapper _mapper;

    public UpdateTaskListCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
        IValidator<UpdateTaskListCommand> validator, IMapper mapper) : base(httpContextAccessor)
    {
        _context = context;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<UpdateTaskListResponse> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        await ValidateRequestAsync(request, cancellationToken);

        var hasAllowedRole = await IsUserOwnerOrEditorAsync(userId, request.TaskListId);
        if (!hasAllowedRole)
            throw new PermissionException("User does not have the required role to update the task list.");

        var taskList = await GetTaskListAsync(request.TaskListId) ??
                       throw new NotFoundException($"Task list with id: {request.TaskListId} could not be found.");


        var updatedTaskList = _mapper.Map<Domain.Entities.TaskList>(request);
        await UpdateTaskListAsync(updatedTaskList);

        return new UpdateTaskListResponse
        {
            Message = $"Task list with ID {taskList.Id} updated successfully",
            TaskListId = updatedTaskList.Id
        };
    }

    private async Task ValidateRequestAsync(UpdateTaskListCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
    }

    private async Task<bool> IsUserOwnerOrEditorAsync(string userId, int taskListId)
    {
        return await _context.TaskListMembers.AnyAsync(q =>
            q.UserId == userId && q.TaskListId == taskListId &&
            (q.Role == TaskListRole.Owner || q.Role == TaskListRole.Editor));
    }

    private async Task<Domain.Entities.TaskList?> GetTaskListAsync(int taskListId)
    {
        return await _context.TaskLists.FirstOrDefaultAsync(q => q.Id == taskListId);
    }


    private async Task UpdateTaskListAsync(Domain.Entities.TaskList taskList)
    {
        taskList.Name = taskList.Name?.Trim();
        taskList.Description = taskList.Description?.Trim();
        taskList.UpdatedAt = DateTime.UtcNow;
        _context.Update(taskList);
        await _context.SaveChangesAsync();
    }
}