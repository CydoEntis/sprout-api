using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetCategoriesWithTaskTaskListCount;

public record GetCategoriesWithTaskListCountQuery(int Page = 1, int PageSize = 10, string? Search = null)
    : IRequest<PagedResponse<GetCategoriesWithTaskListCountResponse>>;

public class CategoryWithTaskListCount
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Color { get; set; }
    public int TotalTaskLists { get; set; }
}

public class GetCategoriesWithTaskListCountResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Color { get; set; }
    public int TotalTaskLists { get; set; }
}

public class GetCategoriesWithTaskListCountHandler : AuthRequiredHandler,
    IRequestHandler<GetCategoriesWithTaskListCountQuery, PagedResponse<GetCategoriesWithTaskListCountResponse>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoriesWithTaskListCountHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
        IMapper mapper)
        : base(httpContextAccessor)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResponse<GetCategoriesWithTaskListCountResponse>> Handle(
        GetCategoriesWithTaskListCountQuery request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();
        var (categories, totalRecords) =
            await GetCategoriesWithTaskListCount(userId, request.Page, request.PageSize, request.Search);

        var responseData = _mapper.Map<List<GetCategoriesWithTaskListCountResponse>>(categories);

        var response = new PagedResponse<GetCategoriesWithTaskListCountResponse>(
            responseData,
            request.Page,
            request.PageSize,
            totalRecords
        );

        return response;
    }


    private async Task<(List<CategoryWithTaskListCount>, int)> GetCategoriesWithTaskListCount(string userId, int page,
        int pageSize, string? search)
    {
        var query = _context.Categories
            .Where(c => c.UserId == userId);

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(c => c.Name.Contains(search));
        }

        var totalRecords = await query.CountAsync();

        var categories = await query
            .OrderBy(c => c.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(c => new CategoryWithTaskListCount
            {
                Id = c.Id,
                Name = c.Name,
                Tag = c.Tag,
                Color = c.Color,
                TotalTaskLists =
                    _context.UserTaskListCategories.Count(utc =>
                        utc.CategoryId == c.Id)
            })
            .ToListAsync();

        return (categories, totalRecords);
    }
}