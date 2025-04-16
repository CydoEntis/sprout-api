using MediatR;
using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Application.Features.TasklistMembers.Queries.GetTasklistMembers;

public static class GetTasklistMembersEndpoint
{
    public static void MapGetTasklistMembersEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/task-list/{taskListId}/members",
                async (int taskListId, IMediator mediator) =>
                {
                    var query = new GetTasklistMembersQuery(taskListId);
                    var response = await mediator.Send(query);
                    return Results.Ok(ApiResponse<List<GetTasklistMembersQueryResponse>>.SuccessWithData(response));
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