using AutoMapper;
using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(int Id, string Name, string Tag, string Color) : IRequest<UpdateCategoryResponse>;

public class UpdateCategoryResponse : BaseResponse
{
    public int CategoryId { get; set; }
}

public class UpdateCategoryCommandHandler(
    IUserContextService userContextService,
    ICategoryRepository categoryRepository,
    IValidationService validationService,
    IMapper mapper) : IRequestHandler<UpdateCategoryCommand, UpdateCategoryResponse>
{
    public async Task<UpdateCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await validationService.ValidateRequestAsync(request, cancellationToken);

        var userId = userContextService.GetAuthenticatedUserId();

        var category = await categoryRepository.GetByIdAsync(userId, request.Id) ??
                       throw new NotFoundException("Category not found or access denied.");

        mapper.Map(request, category);
        await categoryRepository.UpdateAsync(category);
        return new UpdateCategoryResponse()
            { Message = $"{category.Name} category has been updated successfully", CategoryId = category.Id };
    }
}