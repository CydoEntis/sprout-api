using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory
{
    public record GetAllTaskListsForCategoryQuery(string CategoryName)
        : IRequest<List<GetAllTaskListsForCategoryResponse>>;

    public class CategoryDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Color { get; set; }
    }

    public class TaskListDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<MemberResponse> Members { get; set; }
        public int TotalTasksCount { get; set; }
        public int CompletedTasksCount { get; set; }
        public double TaskCompletionPercentage { get; set; }
    }

    public class GetAllTaskListsForCategoryResponse
    {
        public CategoryDetails CategoryDetails { get; set; }
        public TaskListDetails TaskListDetails { get; set; }
    }

    public class GetAllTaskListsForCategoryQueryHandler : AuthRequiredHandler,
        IRequestHandler<GetAllTaskListsForCategoryQuery, List<GetAllTaskListsForCategoryResponse>>
    {
        private readonly AppDbContext _context;
        private readonly IValidator<GetAllTaskListsForCategoryQuery> _validator;
        private readonly IMapper _mapper;

        public GetAllTaskListsForCategoryQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
            IValidator<GetAllTaskListsForCategoryQuery> validator, IMapper mapper) : base(
            httpContextAccessor)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<List<GetAllTaskListsForCategoryResponse>> Handle(
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

        private async Task<List<GetAllTaskListsForCategoryResponse>> GetAllTaskListsByUserIdAndCategoryId(string userId,
            Category existingCategory)
        {
            var taskListsData = await _context.UserTaskListCategories
                .AsNoTracking()
                .Where(ut => ut.UserId == userId && ut.CategoryId == existingCategory.Id)
                .Select(ut => new GetAllTaskListsForCategoryResponse
                {
                    CategoryDetails = new CategoryDetails
                    {
                        Id = ut.Category.Id,
                        Name = ut.Category.Name,
                        Tag = ut.Category.Tag,
                        Color = ut.Category.Color
                    },
                    TaskListDetails = new TaskListDetails
                    {
                        Id = ut.TaskList.Id,
                        Name = ut.TaskList.Name,
                        Description = ut.TaskList.Description,
                        CreatedAt = ut.TaskList.CreatedAt,
                        UpdatedAt = ut.TaskList.UpdatedAt,
                        Members = ut.TaskList.TaskListMembers
                            .Select(tlm => new MemberResponse
                            {
                                UserId = tlm.UserId,
                                Name = tlm.User.LastName + " " + tlm.User.FirstName,
                            })
                            .ToList(),
                        TotalTasksCount = ut.TaskList.TaskListItems.Count(),
                        CompletedTasksCount = ut.TaskList.TaskListItems.Count(ti => ti.IsCompleted),
                        TaskCompletionPercentage = ut.TaskList.TaskListItems.Any()
                            ? Math.Round((ut.TaskList.TaskListItems.Count(ti => ti.IsCompleted) /
                                          (double)Math.Max(1, ut.TaskList.TaskListItems.Count())) * 100, 2)
                            : 0
                    }
                })
                .ToListAsync();

            if (!taskListsData.Any())
            {
                return new List<GetAllTaskListsForCategoryResponse>
                {
                    new GetAllTaskListsForCategoryResponse
                    {
                        CategoryDetails = new CategoryDetails
                        {
                            Id = existingCategory.Id,
                            Name = existingCategory.Name,
                            Tag = existingCategory.Tag,
                            Color = existingCategory.Color
                        },
                        TaskListDetails = null // No task list available
                    }
                };
            }

            return taskListsData;
        }
    }
}