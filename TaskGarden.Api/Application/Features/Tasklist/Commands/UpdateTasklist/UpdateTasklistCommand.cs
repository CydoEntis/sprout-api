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

public record UpdateTasklistCommand(int TaskListId, string Name, string Description) : IRequest<UpdateTaskListResponse>;

public class UpdateTaskListResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class UpdateTaskListCommandHandler : AuthRequiredHandler,
    IRequestHandler<UpdateTasklistCommand, UpdateTaskListResponse>
{
    private readonly AppDbContext _context;
    private readonly IValidator<UpdateTasklistCommand> _validator;
    private readonly IMapper _mapper;

    public UpdateTaskListCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
        IValidator<UpdateTasklistCommand> validator, IMapper mapper) : base(httpContextAccessor)
    {
        _context = context;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<UpdateTaskListResponse> Handle(UpdateTasklistCommand request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var hasAllowedRole = await _context.TaskListMembers.IsOwnerOrEditorAsync(userId, request.TaskListId);
        if (!hasAllowedRole)
            throw new PermissionException("User does not have the required role to update the task list.");

        var taskList = await _context.Tasklists.GetByIdAsync(request.TaskListId) ??
                       throw new NotFoundException($"Task list with id: {request.TaskListId} could not be found.");


        var updatedTaskList = _mapper.Map<Domain.Entities.Tasklist>(request);
        await UpdateTaskListAsync(updatedTaskList);

        return new UpdateTaskListResponse
        {
            Message = $"Task list with ID {taskList.Id} updated successfully",
            TaskListId = updatedTaskList.Id
        };
    }


    private async Task UpdateTaskListAsync(Domain.Entities.Tasklist tasklist)
    {
        tasklist.Name = tasklist.Name?.Trim();
        tasklist.Description = tasklist.Description?.Trim();
        tasklist.UpdatedAt = DateTime.UtcNow;
        _context.Update(tasklist);
        await _context.SaveChangesAsync();
    }
}