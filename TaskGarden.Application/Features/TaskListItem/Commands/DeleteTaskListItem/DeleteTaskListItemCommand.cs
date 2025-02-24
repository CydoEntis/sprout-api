using AutoMapper;
using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.TaskListItem.Commands.DeleteTaskListItem;

public record DeleteTaskListItemCommand(string Name, string Tag) : IRequest<DeleteTaskListItemResponse>;

public class DeleteTaskListItemResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class DeleteTaskListItemCommandHandler(
    IUserContextService userContextService,
    IValidator<DeleteTaskListItemCommand> validator,
    IMapper mapper) : IRequestHandler<DeleteTaskListItemCommand, DeleteTaskListItemResponse>
{
    public async Task<DeleteTaskListItemResponse> Handle(DeleteTaskListItemCommand request,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var userId = userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedException("Invalid user");

        // var existingCategory = await categoryRepository.GetByNameAsync(userId, request.Name);
        // if (existingCategory != null)
        //     throw new ConflictException($"Category with name {request.Name} already exists");
        //
        //
        // var category = mapper.Map<Domain.Entities.TaskListItem>(request);
        // category.UserId = userId!;
        //
        // await categoryRepository.AddAsync(category);
        return new DeleteTaskListItemResponse()
            { Message = $"Task list item with id {1} was deleted", TaskListId = 1 };
    }
}