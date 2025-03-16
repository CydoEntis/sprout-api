using AutoMapper;
using FluentValidation;
using MediatR;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.Categories.Queries.GetAllTaskListsForCategory
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
        public List<MemberResponse> Members { get; set; }
        public int TotalTasksCount { get; set; }
        public int CompletedTasksCount { get; set; }
        public double TaskCompletionPercentage { get; set; }
    }

    public class GetAllTaskListsForCategoryQueryHandler(
        IUserContextService userContextService,
        ICategoryRepository categoryRepository,
        IUserTaskListCategoryRepository userTaskListCategoryRepository,
        IValidationService validationService,
        IMapper mapper)
        :
            IRequestHandler<GetAllTaskListsForCategoryQuery, List<GetAllTaskListsForCategoryResponse>>
    {
        public async Task<List<GetAllTaskListsForCategoryResponse>> Handle(
            GetAllTaskListsForCategoryQuery request,
            CancellationToken cancellationToken)
        {
            var userId = userContextService.GetAuthenticatedUserId();
            await validationService.ValidateRequestAsync(request, cancellationToken);

            var existingCategory = await categoryRepository.GetByNameAsync(userId, request.CategoryName);
            if (existingCategory is null)
                throw new NotFoundException("Category does not exist");

            var taskLists =
                await userTaskListCategoryRepository.GetAllTaskListsByUserIdAndCategoryId(userId, existingCategory.Id);

            return mapper.Map<List<GetAllTaskListsForCategoryResponse>>(taskLists);
        }
    }
}