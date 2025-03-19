using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Projections;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;

public record GetAllCategoriesQuery() : IRequest<List<GetAllCategoriesQueryResponse>>;

public class GetAllCategoriesQueryResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Color { get; set; }
    public int TaskListCount { get; set; }
}

public class GetAllCategoriesQueryHandler : AuthRequiredHandler,
    IRequestHandler<GetAllCategoriesQuery, List<GetAllCategoriesQueryResponse>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context, IMapper mapper)
        : base(httpContextAccessor)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var categories = await GetCategoryPreviewByUserId(userId);
        return _mapper.Map<List<GetAllCategoriesQueryResponse>>(categories);
    }

    private async Task<List<CategoryWithTaskListCount>> GetCategoryPreviewByUserId(string userId)
    {
        var categories = await _context.UserTaskListCategories
            .Where(ut => ut.UserId == userId)
            .Include(ut => ut.Category)
            .Include(ut => ut.TaskList)
            .GroupBy(ut => ut.Category)
            .Select(g => new CategoryWithTaskListCount
            {
                Category = g.Key,
                TaskListCount = g.Count()
            })
            .ToListAsync();

        return categories;
    }
}