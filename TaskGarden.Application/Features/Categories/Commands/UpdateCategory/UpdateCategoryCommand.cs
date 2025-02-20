using MediatR;
using TaskGarden.Application.Features.Shared.Models;

namespace TaskGarden.Application.Features.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(int Id, string Name, string Tag) : IRequest<UpdateCategoryResponse>;

public class UpdateCategoryResponse : BaseResponse
{
    public int CategoryId { get; set; }
}