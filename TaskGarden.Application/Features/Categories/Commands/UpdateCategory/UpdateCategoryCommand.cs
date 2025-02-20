using MediatR;
using TaskGarden.Application.Features.Shared.Models;

namespace TaskGarden.Application.Features.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(int Id, string Name, string Tag) : IRequest<UpdateCategoryResponse>;

public class UpdateCategoryResponse : BaseResponse
{
    public int CategoryId { get; set; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryResponse>
{
    //TODO: Implement Logic.
    public Task<UpdateCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}