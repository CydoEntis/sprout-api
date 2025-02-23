using AutoMapper;
using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Features.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string Name, string Tag) : IRequest<CreateCategoryResponse>;

public class CreateCategoryResponse : BaseResponse
{
    public int CategoryId { get; set; }
}

public class CreateCategoryCommandHandler(
    IUserContextService userContextService,
    ICategoryRepository categoryRepository,
    IValidator<CreateCategoryCommand> createCategoryValidator,
    IMapper mapper) : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
{
    public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await createCategoryValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var userId = userContextService.GetUserId();

        var category = mapper.Map<Category>(request);
        category.UserId = userId!;

        await categoryRepository.AddAsync(category);
        return new CreateCategoryResponse()
            { Message = $"{category.Name} category has been created", CategoryId = category.Id };
    }
}