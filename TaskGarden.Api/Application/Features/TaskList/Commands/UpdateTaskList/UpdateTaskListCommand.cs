using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Application.Common.Exceptions;
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

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var hasAllowedRole = await _context.TaskListMembers.IsUserOwnerOrEditorAsync(userId, request.TaskListId);
        if (!hasAllowedRole)
            throw new PermissionException("User does not have the required role to update the task list.");

        var taskList = await _context.TaskLists.GetByIdAsync(request.TaskListId) ??
                       throw new NotFoundException($"Task list with id: {request.TaskListId} could not be found.");


        var updatedTaskList = _mapper.Map<Domain.Entities.TaskList>(request);
        await UpdateTaskListAsync(updatedTaskList);

        return new UpdateTaskListResponse
        {
            Message = $"Task list with ID {taskList.Id} updated successfully",
            TaskListId = updatedTaskList.Id
        };
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