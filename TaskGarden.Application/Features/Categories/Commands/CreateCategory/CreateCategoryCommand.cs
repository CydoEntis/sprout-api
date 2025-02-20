using MediatR;
using TaskGarden.Application.Features.Shared.Models;

namespace TaskGarden.Application.Features.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string Name, string Tag) : IRequest<CreateCategoryResponse>;

public class CreateCategoryResponse : BaseResponse
{
    public int CategoryId { get; set; }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
{
    //TODO: Implement Logic.
    public Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}