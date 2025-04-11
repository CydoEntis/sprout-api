using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Application.Common.Exceptions;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetCategory;

public record GetCategoryQuery(string CategoryName) : IRequest<GetCategoryResponse>;

public class GetCategoryResponse
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CategoryTag { get; set; }
    public string CategoryColor { get; set; }
}

public class GetCategoryHandler : AuthRequiredHandler,
    IRequestHandler<GetCategoryQuery, GetCategoryResponse>
{
    private readonly AppDbContext _context;

    public GetCategoryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context) : base(
        httpContextAccessor)
    {
        _context = context;
    }

    public async Task<GetCategoryResponse> Handle(
        GetCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var existingCategory = await GetCategoryByNameAsync(userId, request.CategoryName);
        if (existingCategory is null)
            throw new NotFoundException("Category does not exist");

        return new GetCategoryResponse
        {
            CategoryId = existingCategory.Id,
            CategoryName = existingCategory.Name,
            CategoryTag = existingCategory.Tag,
            CategoryColor = existingCategory.Color,
        };
    }

    private async Task<Category?> GetCategoryByNameAsync(string userId, string categoryName)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(c =>
                c.UserId == userId && c.Name.ToLower() == categoryName.ToLower());
    }
}