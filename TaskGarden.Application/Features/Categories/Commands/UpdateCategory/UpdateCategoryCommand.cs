using AutoMapper;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(int Id, string Name, string Tag) : IRequest<UpdateCategoryResponse>;

public class UpdateCategoryResponse : BaseResponse
{
    public int CategoryId { get; set; }
}

public class UpdateCategoryCommandHandler(
    IUserContextService userContextService,
    ICategoryRepository categoryRepository,
    IMapper mapper) : IRequestHandler<UpdateCategoryCommand, UpdateCategoryResponse>
{
    public async Task<UpdateCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var category = await categoryRepository.GetAsync(request.Id);
        if (category == null)
            throw new NotFoundException("Category not found.");

        if (category.UserId != userId)
            throw new PermissionException("You are not the owner of this category.");

        mapper.Map(request, category);
        await categoryRepository.UpdateAsync(category);
        return new UpdateCategoryResponse()
            { Message = $"{category.Name} category has been updated successfully", CategoryId = category.Id };
    }
}