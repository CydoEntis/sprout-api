using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(int CategoryId) : IRequest<DeleteCategoryResponse>;

public class DeleteCategoryResponse : BaseResponse;

public class DeleteCategoryCommandHandler(
    IUserContextService userContextService,
    ICategoryRepository categoryRepository
) : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>
{
    public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetAuthenticatedUserId();

        var category = await categoryRepository.GetByIdAsync(userId, request.CategoryId) ??
                       throw new NotFoundException("Category not found or access denied.");


        if (!await categoryRepository.DeleteCategoryAndDependenciesAsync(category))
            throw new ResourceModificationException("Category could not be deleted.");

        return new DeleteCategoryResponse() { Message = $"{category.Name} category has been deleted successfully" };
    }
}