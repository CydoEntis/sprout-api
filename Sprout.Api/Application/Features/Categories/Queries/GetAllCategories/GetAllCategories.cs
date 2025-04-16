using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Api.Application.Shared.Handlers;
using Sprout.Api.Infrastructure.Persistence;

namespace Sprout.Api.Application.Features.Categories.Queries.GetAllCategories;

public record GetAllCategoriesQuery() : IRequest<List<GetAllCategoriesResponse>>;

public class GetAllCategoriesResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Color { get; set; }
}

public class GetAllCategoriesHandler : AuthRequiredHandler,
    IRequestHandler<GetAllCategoriesQuery, List<GetAllCategoriesResponse>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetAllCategoriesHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context, IMapper mapper)
        : base(httpContextAccessor)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetAllCategoriesResponse>> Handle(
        GetAllCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var categories = await _context.Categories
            .Where(c => c.UserId == userId)
            .Select(c => new GetAllCategoriesResponse
            {
                Id = c.Id,
                Name = c.Name,
                Tag = c.Tag,
                Color = c.Color
            })
            .ToListAsync(cancellationToken);

        return categories;
    }
}