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
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory
{
    public record GetAllTaskListsForCategoryQuery(string CategoryName)
        : IRequest<GetAllTaskListsForCategoryResponse>;

    public class GetAllTaskListsForCategoryResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryTag { get; set; }
        public string CategoryColor { get; set; }
        public List<TaskListOverview> TaskListOverviews { get; set; } = new();
    }

    public class GetAllTaskListsForCategoryQueryHandler : AuthRequiredHandler,
        IRequestHandler<GetAllTaskListsForCategoryQuery, GetAllTaskListsForCategoryResponse>
    {
        private readonly AppDbContext _context;
        private readonly IValidator<GetAllTaskListsForCategoryQuery> _validator;

        public GetAllTaskListsForCategoryQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
            IValidator<GetAllTaskListsForCategoryQuery> validator) : base(httpContextAccessor)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<GetAllTaskListsForCategoryResponse> Handle(
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

            var taskLists = await GetAllTaskListsByUserIdAndCategoryId(userId, existingCategory);

            return taskLists;
        }

        private async Task<Category?> GetCategoryByNameAsync(string userId, string categoryName)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c =>
                    c.UserId == userId && c.Name.ToLower() == categoryName.ToLower());
        }

        private async Task<GetAllTaskListsForCategoryResponse> GetAllTaskListsByUserIdAndCategoryId(string userId,
            Category existingCategory)
        {
            var taskListOverviews = await _context.UserTaskListCategories
                .AsNoTracking()
                .Where(ut => ut.UserId == userId && ut.CategoryId == existingCategory.Id)
                .Select(ut => new TaskListOverview
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
                })
                .ToListAsync();

            return new GetAllTaskListsForCategoryResponse
            {
                CategoryId = existingCategory.Id,
                CategoryName = existingCategory.Name,
                CategoryTag = existingCategory.Tag,
                CategoryColor = existingCategory.Color,
                TaskListOverviews = taskListOverviews
            };
        }
    }
}