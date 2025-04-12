using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.TaskList.Commands.CreateTaskListWithCategory;

public static class CreateTaskListWithCategoryEndpoint
{
    public static void MapCreateTaskListWithCategoryEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/task-list/with-category", async (CreateTaskListWithCategoryCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<CreateTaskListWithCategoryResponse>.SuccessWithData(response));
            })
            .WithName("CreateTaskListWithCategory")
            .WithTags("Task List")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);
    }
}