using MediatR;
using TaskGarden.Application.Features.Shared.Models;

namespace TaskGarden.Application.Features.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(int Id) : IRequest<DeleteCategoryResponse>;

public class DeleteCategoryResponse : BaseResponse;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>
{
    //TODO: Implement Logic.
    public Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}