using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.TaskList.Commands.UpdateTaskList;

public static class UpdateTasklistEndpoint
{
    public static void MapUpdateTaskListEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPut("/api/task-list", async (UpdateTasklistCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<UpdateTaskListResponse>.SuccessWithData(response));
            })
            .WithName("UpdateTaskList")
            .WithTags("Task List")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}