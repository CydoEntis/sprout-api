using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Extensions;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Domain.Entities;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(int CategoryId) : IRequest<DeleteCategoryResponse>;

public class DeleteCategoryResponse : BaseResponse;

public class DeleteCategoryCommandHandler :
    IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>
{
    private readonly AppDbContext _context;

    public DeleteCategoryCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.GetByIdAsync(request.CategoryId) ??
                       throw new NotFoundException("Category not found or access denied.");

        if (!await DeleteCategoryAndDependenciesAsync(category))
            throw new ResourceModificationException("Category could not be deleted.");

        return new DeleteCategoryResponse() { Message = $"{category.Name} category has been deleted successfully" };
    }

    private async Task<bool> DeleteCategoryAndDependenciesAsync(Category category)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var taskListIds = await GetTaskListIdsByCategoryAsync(category.Id);

            if (taskListIds.Any())
            {
                await DeleteTaskListsAndDependenciesAsync(taskListIds);
            }

            await DeleteCategoryAsync(category);
            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }

    private async Task<List<int>> GetTaskListIdsByCategoryAsync(int categoryId)
    {
        return await _context.UserTaskListCategories
            .Where(utc => utc.CategoryId == categoryId)
            .Select(utc => utc.TaskListId)
            .ToListAsync();
    }


    private async Task DeleteTaskListsAndDependenciesAsync(List<int> taskListIds)
    {
        await DeleteTaskListItems(taskListIds);
        await DeleteTaskListMembers(taskListIds);
        await DeleteTaskLists(taskListIds);
    }

    private async Task DeleteTaskListItems(List<int> taskListIds)
    {
        await _context.TaskListItems
            .Where(tli => taskListIds.Contains(tli.TaskListId))
            .ExecuteDeleteAsync();
    }

    private async Task DeleteTaskListMembers(List<int> taskListIds)
    {
        await _context.TaskListMembers
            .Where(tla => taskListIds.Contains(tla.TaskListId))
            .ExecuteDeleteAsync();
    }

    private async Task DeleteTaskLists(List<int> taskListIds)
    {
        await _context.TaskLists
            .Where(t => taskListIds.Contains(t.Id))
            .ExecuteDeleteAsync();
    }

    private async Task DeleteCategoryAsync(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}