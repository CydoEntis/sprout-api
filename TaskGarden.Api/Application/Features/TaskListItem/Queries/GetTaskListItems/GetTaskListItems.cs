using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Api.Infrastructure.Persistence;

namespace TaskGarden.Api.Application.Features.TasklistItem.Queries.GetTaskListItems
{
    public record GetTaskListItemsQuery(int TaskListId, int Page, int PageSize)
        : IRequest<PagedResponse<TasklistItemDetail>>;

    public class
        GetTaskListItemsQueryHandler : IRequestHandler<GetTaskListItemsQuery, PagedResponse<TasklistItemDetail>>
    {
        private readonly AppDbContext _context;

        public GetTaskListItemsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<TasklistItemDetail>> Handle(GetTaskListItemsQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.TaskListItems
                .Where(t => t.TasklistId == request.TaskListId)
                .OrderBy(t => t.Position)
                .Select(t => new TasklistItemDetail
                {
                    Id = t.Id,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    Position = t.Position,
                });

            var totalCount = await query.CountAsync(cancellationToken);
            var items = await query.Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedResponse<TasklistItemDetail>(items, request.Page, request.PageSize, totalCount);
        }
    }
}