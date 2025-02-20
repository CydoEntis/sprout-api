using AutoMapper;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services;

namespace TaskGarden.Application.Features.Categories.Queries.GetAllCategories;

public record GetAllCategoriesQuery() : IRequest<List<GetAllCategoriesQueryResponse>>;

public class GetAllCategoriesQueryResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public int TaskListCount { get; set; }
}

public class GetAllCategoriesQueryHandler(
    UserContextService userContextService,
    ICategoryRepository categoryRepository,
    IMapper mapper)
    : IRequestHandler<GetAllCategoriesQuery, List<GetAllCategoriesQueryResponse>>
{
    public async Task<List<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var userId = userContextService.GetUserId();
        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated");

        var categories = await categoryRepository.GetAllCategoriesTaskListsAsync(userId);
        return mapper.Map<List<GetAllCategoriesQueryResponse>>(categories);
    }
}