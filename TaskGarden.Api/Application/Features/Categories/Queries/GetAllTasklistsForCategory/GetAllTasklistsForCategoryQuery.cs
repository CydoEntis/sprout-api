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
    public record GetAllTasklistsForCategoryQuery(string CategoryName)
        : IRequest<List<GetAllTaskListsForCategoryResponse>>;


    public class GetAllTaskListsForCategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Color { get; set; }
        public List<TasklistInfo> TasklistsInfo { get; set; }
    }

    public class GetAllTaskListsForCategoryQueryHandler : AuthRequiredHandler,
        IRequestHandler<GetAllTasklistsForCategoryQuery, List<GetAllTaskListsForCategoryResponse>>
    {
        private readonly AppDbContext _context;
        private readonly IValidator<GetAllTasklistsForCategoryQuery> _validator;
        private readonly IMapper _mapper;

        public GetAllTaskListsForCategoryQueryHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
            IValidator<GetAllTasklistsForCategoryQuery> validator, IMapper mapper) : base(
            httpContextAccessor)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<List<GetAllTaskListsForCategoryResponse>> Handle(
            GetAllTasklistsForCategoryQuery request,
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
                .GroupBy(ut => new
                {
                    ut.Category.Id,
                    ut.Category.Name,
                    ut.Category.Tag,
                    ut.Category.Color
                })
                .Select(g => new GetAllTaskListsForCategoryResponse
                {
                    Id = g.Key.Id,
                    Name = g.Key.Name,
                    Tag = g.Key.Tag,
                    Color = g.Key.Color,
                    TasklistsInfo = g.Select(ut => new TasklistInfo
                    {
                        Id = ut.Tasklist.Id,
                        Name = ut.Tasklist.Name,
                        Description = ut.Tasklist.Description,
                        CreatedAt = ut.Tasklist.CreatedAt,
                        UpdatedAt = ut.Tasklist.UpdatedAt,
                        Members = ut.Tasklist.TaskListMembers
                            .Select(tlm => new Member()
                            {
                                Id = tlm.UserId,
                                Name = tlm.User.LastName + " " + tlm.User.FirstName,
                            })
                            .ToList(),
                        TotalTasksCount = ut.Tasklist.TaskListItems.Count(),
                        CompletedTasksCount = ut.Tasklist.TaskListItems.Count(ti => ti.IsCompleted),
                        TaskCompletionPercentage = ut.Tasklist.TaskListItems.Any()
                            ? Math.Round((ut.Tasklist.TaskListItems.Count(ti => ti.IsCompleted) /
                                          (double)Math.Max(1, ut.Tasklist.TaskListItems.Count())) * 100, 2)
                            : 0
                    }).ToList()
                })
                .ToListAsync();

            if (!taskListsData.Any())
            {
                return new List<GetAllTaskListsForCategoryResponse>
                {
                    new GetAllTaskListsForCategoryResponse
                    {
                        Id = existingCategory.Id,
                        Name = existingCategory.Name,
                        Tag = existingCategory.Tag,
                        Color = existingCategory.Color,
                        TasklistsInfo = new List<TasklistInfo>() 
                    }
                };
            }

            return taskListsData;
        }
    }
}