using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Application.Common.Exceptions;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory
{
    public record GetAllTaskListsForCategoryQuery(
        string CategoryName,
        int Page = 1,
        int PageSize = 10,
        string? Search = null,
        string SortBy = "createdAt",
        string SortDirection = "desc"
    ) : IRequest<PagedResponse<GetAllTaskListsForCategoryResponse>>;

    public class GetAllTaskListsForCategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Member> Members { get; set; } = new List<Member>();
        public int RemainingMembers { get; set; }
        public double TaskCompletionPercentage { get; set; }
        public bool IsFavorited { get; set; }
    }

    public class GetAllTaskListsForCategoryQueryHandler : AuthRequiredHandler,
        IRequestHandler<GetAllTaskListsForCategoryQuery, PagedResponse<GetAllTaskListsForCategoryResponse>>
    {
        private readonly AppDbContext _context;
        private readonly IValidator<GetAllTaskListsForCategoryQuery> _validator;

        public GetAllTaskListsForCategoryQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
            IValidator<GetAllTaskListsForCategoryQuery> validator) : base(httpContextAccessor)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<PagedResponse<GetAllTaskListsForCategoryResponse>> Handle(
            GetAllTaskListsForCategoryQuery request,
            CancellationToken cancellationToken)
        {
            var userId = GetAuthenticatedUserId();

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingCategory = await GetCategoryByNameAsync(userId, request.CategoryName);
            if (existingCategory is null)
                throw new NotFoundException("Category does not exist");

            var (taskLists, totalRecords) =
                await GetAllTaskListsByUserIdAndCategoryId(userId, existingCategory, request);

            return new PagedResponse<GetAllTaskListsForCategoryResponse>(
                taskLists,
                request.Page,
                request.PageSize,
                totalRecords
            );
        }

        private async Task<Category?> GetCategoryByNameAsync(string userId, string categoryName)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c =>
                    c.UserId == userId && c.Name.ToLower() == categoryName.ToLower());
        }

        private async Task<(List<GetAllTaskListsForCategoryResponse>, int)> GetAllTaskListsByUserIdAndCategoryId(
            string userId,
            Category existingCategory,
            GetAllTaskListsForCategoryQuery request)
        {
            var query = _context.UserTaskListCategories
                .AsNoTracking()
                .Where(ut => ut.UserId == userId && ut.CategoryId == existingCategory.Id)
                .Select(ut => new GetAllTaskListsForCategoryResponse
                {
                    Id = ut.TaskList.Id,
                    Name = ut.TaskList.Name,
                    Description = ut.TaskList.Description,
                    CreatedAt = ut.TaskList.CreatedAt,
                    UpdatedAt = ut.TaskList.UpdatedAt,

                    Members = ut.TaskList.TaskListMembers
                        .OrderBy(tlm => tlm.User.LastName)
                        .ThenBy(tlm => tlm.User.FirstName)
                        .Take(5)
                        .Select(tlm => new Member
                        {
                            UserId = tlm.UserId,
                            Name = tlm.User.LastName + " " + tlm.User.FirstName,
                        })
                        .ToList(),

                    RemainingMembers = ut.TaskList.TaskListMembers.Count() > 5
                        ? ut.TaskList.TaskListMembers.Count() - 5
                        : 0,

                    TaskCompletionPercentage = ut.TaskList.TaskListItems.Any()
                        ? Math.Round((ut.TaskList.TaskListItems.Count(ti => ti.IsCompleted) /
                                      (double)Math.Max(1, ut.TaskList.TaskListItems.Count())) * 100, 2)
                        : 0,

                    IsFavorited = _context.FavoriteTaskLists
                        .Any(f => f.UserId == userId && f.TaskListId == ut.TaskList.Id),
                });

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var lowerSearch = request.Search.ToLower();
                query = query.Where(ut => ut.Name.ToLower().Contains(lowerSearch));
            }

            query = (request.SortBy.ToLower(), request.SortDirection.ToLower()) switch
            {
                ("name", "asc") => query.OrderBy(ut => ut.Name),
                ("name", "desc") => query.OrderByDescending(ut => ut.Name),
                ("createdat", "asc") => query.OrderBy(ut => ut.CreatedAt),
                _ => query.OrderByDescending(ut => ut.CreatedAt)
            };

            var totalRecords = await query.CountAsync();

            var taskListOverviews = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return (taskListOverviews, totalRecords);
        }
    }
}