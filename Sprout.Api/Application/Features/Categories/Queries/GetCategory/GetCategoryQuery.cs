using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Api.Application.Shared.Handlers;
using Sprout.Api.Domain.Entities;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Application.Common.Exceptions;

namespace Sprout.Api.Application.Features.Categories.Queries.GetCategory;

public record GetCategoryQuery(string CategoryName) : IRequest<GetCategoryResponse>;

public class GetCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public string Color { get; set; }
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
            Id = existingCategory.Id,
            Name = existingCategory.Name,
            Tag = existingCategory.Tag,
            Color = existingCategory.Color,
        };
    }

    private async Task<Category?> GetCategoryByNameAsync(string userId, string categoryName)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(c =>
                c.UserId == userId && c.Name.ToLower() == categoryName.ToLower());
    }
}