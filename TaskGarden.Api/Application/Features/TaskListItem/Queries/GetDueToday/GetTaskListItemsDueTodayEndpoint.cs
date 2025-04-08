using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.TaskListItem.Queries.GetDueToday;

public static class GetTaskListItemsDueTodayEndpoint
{
    public static void MapGetTaskListItemsDueTodayEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/task-list/today",
                async (IMediator mediator, [FromQuery] int taskListId, [FromQuery] int page = 1,
                    [FromQuery] int pageSize = 20) =>
                {
                    var query = new GetTaskListItemsDueTodayQuery(taskListId, page, pageSize);
                    var response = await mediator.Send(query);
                    return Results.Ok(
                        ApiResponse<PagedResponse<TodaysTaskListItem>>.SuccessWithData(response));
                })
            .WithName("GetDueToday")
            .WithTags("Task List Item")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}