using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Infrastructure.Persistence;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetCategoriesWithTaskListCount;

public record GetCategoriesWithTaskListCountQuery(
    int Page = 1,
    int PageSize = 10,
    string? Search = null,
    string SortBy = "createdAt",
    string SortDirection = "desc"
) : IRequest<PagedResponse<GetCategoriesWithTaskListCountResponse>>;

public class GetCategoriesWithTaskListCountResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Color { get; set; }
    public int TotalTaskLists { get; set; }
}

public class GetCategoriesWithTasklistCountHandler : AuthRequiredHandler,
    IRequestHandler<GetCategoriesWithTaskListCountQuery, PagedResponse<GetCategoriesWithTaskListCountResponse>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoriesWithTasklistCountHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
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
        var (categories, totalRecords) = await GetCategoriesWithTaskListCount(
            userId,
            request.Page,
            request.PageSize,
            request.Search,
            request.SortBy,
            request.SortDirection
        );

        var response = new PagedResponse<GetCategoriesWithTaskListCountResponse>(
            categories,
            request.Page,
            request.PageSize,
            totalRecords
        );

        return response;
    }

    private async Task<(List<GetCategoriesWithTaskListCountResponse>, int)> GetCategoriesWithTaskListCount(
        string userId,
        int page,
        int pageSize,
        string? search,
        string sortBy,
        string sortDirection)
    {
        var query = _context.Categories
            .Where(c => c.UserId == userId);

        if (!string.IsNullOrWhiteSpace(search))
        {
            var lowerSearch = search.ToLower();
            query = query.Where(c => c.Name.ToLower().Contains(lowerSearch));
        }

        query = (sortBy.ToLower(), sortDirection.ToLower()) switch
        {
            ("name", "asc") => query.OrderBy(c => c.Name),
            ("name", "desc") => query.OrderByDescending(c => c.Name),
            ("createdat", "asc") => query.OrderBy(c => c.CreatedAt),
            _ => query.OrderByDescending(c => c.CreatedAt)
        };

        var totalRecords = await query.CountAsync();

        var categories = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(c => new GetCategoriesWithTaskListCountResponse
            {
                Id = c.Id,
                Name = c.Name,
                Tag = c.Tag,
                Color = c.Color,
                TotalTaskLists = _context.UserTaskListCategories.Count(utc => utc.CategoryId == c.Id)
            })
            .ToListAsync();

        return (categories, totalRecords);
    }
}
