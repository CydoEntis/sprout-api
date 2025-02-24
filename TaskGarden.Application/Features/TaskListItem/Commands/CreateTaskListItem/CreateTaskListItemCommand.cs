using AutoMapper;
using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.TaskListItem.Commands.CreateTaskListItem;

public record CreateTaskListItemCommand(string Name, string Tag) : IRequest<CreateTaskListItemResponse>;

public class CreateTaskListItemResponse : BaseResponse
{
    public int TaskListId { get; set; }
}

public class CreateTaskListItemCommandHandler(
    IUserContextService userContextService,
    IValidator<CreateTaskListItemCommand> validator,
    IMapper mapper) : IRequestHandler<CreateTaskListItemCommand, CreateTaskListItemResponse>
{
    public async Task<CreateTaskListItemResponse> Handle(CreateTaskListItemCommand request,
        CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var userId = userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedException("Invalid user");
        //     
        //     var existingCategory = await categoryRepository.GetByNameAsync(userId, request.Name);
        //     if(existingCategory != null)
        //         throw new ConflictException($"Category with name {request.Name} already exists");
        //     
        //
        //     var category = mapper.Map<Domain.Entities.TaskListItem>(request);
        //     category.UserId = userId!;
        //
        //     await categoryRepository.AddAsync(category);
        //     return new CreateTaskListItemResponse()
        //         { Message = $"{category.Name} category has been created", CategoryId = category.Id };
        return new CreateTaskListItemResponse() { Message = $"Item added", TaskListId = 1 };
    }
}