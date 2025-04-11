using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Infrastructure.Persistence;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;

public record GetAllCategoriesQuery(
    int Page = 1,
    int PageSize = 10,
    string? Search = null,
    string SortBy = "createdAt",
    string SortDirection = "desc"
) : IRequest<PagedResponse<GetAllCategoriesResponse>>;

public class GetAllCategoriesResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Color { get; set; }
}

public class GetAllCategoriesHandler : AuthRequiredHandler,
    IRequestHandler<GetAllCategoriesQuery, PagedResponse<GetAllCategoriesResponse>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCategoriesHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context, IMapper mapper)
        : base(httpContextAccessor)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResponse<GetAllCategoriesResponse>> Handle(
        GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var query = _context.Categories
            .Where(c => c.UserId == userId);

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var search = request.Search.ToLower();
            query = query.Where(c => c.Name.ToLower().Contains(search));
        }

        query = (request.SortBy.ToLower(), request.SortDirection.ToLower()) switch
        {
            ("name", "asc") => query.OrderBy(c => c.Name),
            ("name", "desc") => query.OrderByDescending(c => c.Name),
            ("createdat", "asc") => query.OrderBy(c => c.CreatedAt),
            _ => query.OrderByDescending(c => c.CreatedAt)
        };

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<GetAllCategoriesResponse>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new PagedResponse<GetAllCategoriesResponse>(items, request.Page, request.PageSize, totalCount);
    }
}