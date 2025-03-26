// using MediatR;
// using TaskGarden.Api.Application.Shared.Models;
//
// namespace TaskGarden.Api.Application.Features.TaskList.Queries.GetTaskListById;
//
// public static class GetTaskListByIdEndpoint
// {
//     public static void MapGetTaskListByIdEndpoint(this IEndpointRouteBuilder routes)
//     {
//         routes.MapGet("/api/task-list/{taskListId:int}",
//                 async (int taskListId, IMediator mediator) =>
//                 {
//                     var query = new GetTaskListByIdQuery(taskListId);
//                     var response = await mediator.Send(query);
//                     return Results.Ok(ApiResponse<GetTaskListByIdQueryResponse>.SuccessWithData(response));
//                 })
//             .WithName("GetTaskListById")
//             .WithTags("Task List")
//             .RequireAuthorization()
//             .Produces(StatusCodes.Status400BadRequest)
//             .Produces(StatusCodes.Status200OK);
//     }
// }