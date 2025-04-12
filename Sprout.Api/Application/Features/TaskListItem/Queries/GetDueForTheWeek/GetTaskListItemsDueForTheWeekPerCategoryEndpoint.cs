using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.TaskListItem.Queries.GetDueForTheWeek;

public static class GetTaskListItemsDueForTheWeekPerCategoryEndpoint
{
    public static void MapGetTaskListItemsDueForTheWeekPerCategoryEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/task-list/coming-up",
                async (IMediator mediator, [FromQuery] int page = 1,
                    [FromQuery] int pageSize = 200) =>
                {
                    var query = new GetTaskListItemsDueForTheWeekPerCategoryQuery(page, pageSize);
                    var response = await mediator.Send(query);
                    return Results.Ok(ApiResponse<PagedResponse<TaskListItemCategoryGroup>>.SuccessWithData(response));
                })
            .WithName("GetDueThisWeek")
            .WithTags("Task List Item")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}