using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Application.Shared.Projections;

namespace TaskGarden.Api.Application.Features.TasklistItem.Queries;

public static class GetTasklistItemsEndpoint
{
    public static void MapGetTasklistItemsEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/task-list/{taskListId}/items",
                async (IMediator mediator, int taskListId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20) =>
                {
                    var query = new GetTaskListItemsQuery(taskListId, page, pageSize);
                    var response = await mediator.Send(query);
                    return Results.Ok(ApiResponse<PagedResponse<TasklistItemDetail>>.SuccessWithData(response));
                })
            .WithName("GetTasklistItems")
            .WithTags("Task List Item")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}