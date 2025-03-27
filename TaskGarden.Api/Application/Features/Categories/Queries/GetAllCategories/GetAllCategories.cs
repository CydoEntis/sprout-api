using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Categories.Queries;

public record GetAllCategoriesQuery()
    : IRequest<List<GetAllCategoriesResponse>>;

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

    public GetAllCategoriesHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
        IMapper mapper)
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
        var categories =
            await GetAllCategories(userId);

        var response = _mapper.Map<List<GetAllCategoriesResponse>>(categories);

        return response;
    }


    private async Task<List<Category>> GetAllCategories(string userId)
    {
        return await _context.Categories
            .Where(c => c.UserId == userId)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }
}