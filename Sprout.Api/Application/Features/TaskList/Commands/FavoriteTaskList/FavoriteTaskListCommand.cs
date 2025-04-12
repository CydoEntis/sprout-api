using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Tasklist.Commands.FavoriteTasklist;

public record FavoriteTaskListCommand(int TaskListId) : IRequest<FavoriteTaskListResponse>;

public class FavoriteTaskListResponse
{
    public int TaskListId { get; set; }
    public bool IsFavorited { get; set; }
}

public class FavoriteTaskListCommandHandler : AuthRequiredHandler,
    IRequestHandler<FavoriteTaskListCommand, FavoriteTaskListResponse>
{
    private readonly AppDbContext _context;

    public FavoriteTaskListCommandHandler(
        IHttpContextAccessor httpContextAccessor,
        AppDbContext context)
        : base(httpContextAccessor)
    {
        _context = context;
    }

    public async Task<FavoriteTaskListResponse> Handle(
        FavoriteTaskListCommand request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var existingFavorite = await _context.FavoriteTaskLists
            .FirstOrDefaultAsync(f => f.UserId == userId && f.TaskListId == request.TaskListId, cancellationToken);

        bool isFavorited;
        if (existingFavorite != null)
        {
            _context.FavoriteTaskLists.Remove(existingFavorite);
            isFavorited = false;
        }
        else
        {
            var newFavorite = new Domain.Entities.FavoriteTaskList
            {
                UserId = userId,
                TaskListId = request.TaskListId
            };
            _context.FavoriteTaskLists.Add(newFavorite);
            isFavorited = true;
        }

        await _context.SaveChangesAsync(cancellationToken);

        return new FavoriteTaskListResponse
        {
            TaskListId = request.TaskListId,
            IsFavorited = isFavorited,
        };
    }
}