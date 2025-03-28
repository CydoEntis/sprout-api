using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.TaskList.Commands.CreateTaskList;

public static class CreateTasklistEndpoint
{
    public static void MapCreateTaskListEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/task-list", async (CreateTasklistCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<CreateTaskListResponse>.SuccessWithData(response));
            })
            .WithName("CreateTaskList")
            .WithTags("Task List")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}