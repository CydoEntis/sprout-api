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
    ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>
{
    //TODO: Implement Logic.
    public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var category = await categoryRepository.GetAsync(request.CategoryId);
        if (category == null)
            throw new NotFoundException("Category not found.");

        if (category.UserId != userId)
            throw new PermissionException("You are not the owner of this category.");

        var result = await categoryRepository.DeleteCategoryAndDependenciesAsync(category);
        if (!result)
            throw new ResourceModificationException("Category could not be deleted.");

        return new DeleteCategoryResponse() { Message = $"{category.Name} category has been deleted successfully" };
    }
}