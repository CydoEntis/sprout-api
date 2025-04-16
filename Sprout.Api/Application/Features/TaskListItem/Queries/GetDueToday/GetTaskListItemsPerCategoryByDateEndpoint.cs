using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Application.Features.TaskListItem.Queries.GetDueToday;

public static class GetTaskListItemsPerCategoryByDateEndpoint
{
    public static void MapGetTaskListItemsPerCategoryByDateEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/task-list/due-by-date",
                async (IMediator mediator,
                    [FromQuery] DateTime date,
                    [FromQuery] int page = 1,
                    [FromQuery] int pageSize = 10,
                    [FromQuery] string? search = null,
                    [FromQuery] string sortBy = "duedate",
                    [FromQuery] string sortDirection = "desc",
                    [FromQuery] bool? isCompleted = null) =>
                {
                    var query = new GetTaskListItemsPerCategoryByDateQuery(
                        date,
                        page,
                        pageSize,
                        search,
                        sortBy,
                        sortDirection,
                        isCompleted
                    );

                    var response = await mediator.Send(query);
                    return Results.Ok(ApiResponse<PagedResponse<TaskListItemCategoryGroup>>.SuccessWithData(response));
                })
            .WithName("GetTaskListItemsPerCategoryByDate")
            .WithTags("Task List Item")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}