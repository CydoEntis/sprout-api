using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory
{
    public record GetAllTaskListsForCategoryQuery(string CategoryName)
        : IRequest<List<GetAllTaskListsForCategoryResponse>>;

    public class GetAllTaskListsForCategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CategoryName { get; set; }
        public List<MemberResponse> Members { get; set; }
        public int TotalTasksCount { get; set; }
        public int CompletedTasksCount { get; set; }
        public double TaskCompletionPercentage { get; set; }
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

            var taskLists = await GetAllTaskListsByUserIdAndCategoryId(userId, existingCategory.Id);

            return _mapper.Map<List<GetAllTaskListsForCategoryResponse>>(taskLists);
        }

        private async Task<Category?> GetCategoryByNameAsync(string userId, string categoryName)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c =>
                    c.UserId == userId && c.Name.ToLower() == categoryName.ToLower());
        }

        private async Task<List<TaskListPreview>> GetAllTaskListsByUserIdAndCategoryId(string userId,
            int categoryId)
        {
            var taskListsData = await _context.UserTaskListCategories
                .Where(ut => ut.UserId == userId && ut.CategoryId == categoryId)
                .Include(ut => ut.Category)
                .Include(ut => ut.TaskList)
                .ThenInclude(t => t.TaskListMembers)
                .Include(ut => ut.TaskList)
                .ThenInclude(t => t.TaskListItems)
                .Select(ut => new TaskListPreview
                {
                    Id = ut.TaskList.Id,
                    Name = ut.TaskList.Name,
                    Description = ut.TaskList.Description,
                    CreatedAt = ut.TaskList.CreatedAt,
                    UpdatedAt = ut.TaskList.UpdatedAt,
                    CategoryName = ut.Category.Name,
                    Members = ut.TaskList.TaskListMembers
                        .Select(tlm => new Member()
                        {
                            Id = tlm.UserId,
                            Name = tlm.User.LastName + " " + tlm.User.FirstName,
                        }).ToList(),
                    TotalTasksCount = ut.TaskList.TaskListItems.Count,
                    CompletedTasksCount = ut.TaskList.TaskListItems.Count(ti => ti.IsCompleted),
                    TaskCompletionPercentage = ut.TaskList.TaskListItems.Count > 0 
                        ? (ut.TaskList.TaskListItems.Count(ti => ti.IsCompleted) / (double)ut.TaskList.TaskListItems.Count) * 100 
                        : 0
                })
                .ToListAsync();

            return taskListsData;
        }
    }
}