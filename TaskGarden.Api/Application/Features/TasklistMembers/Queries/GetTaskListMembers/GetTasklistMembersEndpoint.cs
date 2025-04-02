using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.TasklistMembers.Queries.GetTasklistMembers;

public static class GetTasklistMembersEndpoint
{
    public static void MapGetTasklistMembersEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/task-list/{taskListId}/members",
                async (int taskListId, IMediator mediator) =>
                {
                    var query = new GetTasklistMembersQuery(taskListId);
                    var response = await mediator.Send(query);
                    return Results.Ok(ApiResponse<GetTasklistMembersQueryResponse>.SuccessWithData(response));
                })
            .WithName("GetTasklistMembers")
            .WithTags("Task List Members")
            .RequireAuthorization()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);
    }
}