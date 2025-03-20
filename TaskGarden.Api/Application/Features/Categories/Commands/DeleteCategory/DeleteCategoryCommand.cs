using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure;

namespace TaskGarden.Application.Features.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(int CategoryId) : IRequest<DeleteCategoryResponse>;

public class DeleteCategoryResponse : BaseResponse;

public class DeleteCategoryCommandHandler : AuthRequiredHandler,
    IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>
{
    private readonly AppDbContext _context;

    public DeleteCategoryCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context) : base(
        httpContextAccessor)
    {
        _context = context;
    }

    public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var userId = GetAuthenticatedUserId();

        var category = await GetCategoryByIdAsync(userId, request.CategoryId) ??
                       throw new NotFoundException("Category not found or access denied.");


        if (!await DeleteCategoryAndDependenciesAsync(category))
            throw new ResourceModificationException("Category could not be deleted.");

        return new DeleteCategoryResponse() { Message = $"{category.Name} category has been deleted successfully" };
    }

    private async Task<Category?> GetCategoryByIdAsync(string userId, int categoryId)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == categoryId && c.UserId == userId);
    }

    private async Task<bool> DeleteCategoryAndDependenciesAsync(Category category)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var categoryId = category.Id;

            var taskListIds = await _context.UserTaskListCategories
                .Where(utc => utc.CategoryId == categoryId)
                .Select(utc => utc.TaskListId)
                .ToListAsync();

            if (taskListIds.Count > 0)
            {
                await _context.TaskListMembers
                    .Where(tla => taskListIds.Contains(tla.TaskListId))
                    .ExecuteDeleteAsync();

                await _context.TaskListItems
                    .Where(tli => taskListIds.Contains(tli.TaskListId))
                    .ExecuteDeleteAsync();

                await _context.TaskLists
                    .Where(t => taskListIds.Contains(t.Id))
                    .ExecuteDeleteAsync();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }
}