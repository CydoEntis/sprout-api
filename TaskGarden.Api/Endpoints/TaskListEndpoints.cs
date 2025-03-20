using MediatR;
using TaskGarden.Api.Application.Features.Invitation.Commands.InviteUser;
using TaskGarden.Api.Application.Features.TaskList.Commands.CreateTaskList;
using TaskGarden.Api.Application.Features.TaskList.Commands.DeleteTaskList;
using TaskGarden.Api.Application.Features.TaskList.Commands.UpdateTaskList;
using TaskGarden.Api.Application.Features.TaskList.Queries.GetTaskListById;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.DeleteTaskListItem;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItem;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItemCompletedStatus;
using TaskGarden.Application.Features.TaskListItem.Commands.ReorderTaskListItem;
using TaskGarden.Infrastructure.Models;

namespace TaskGarden.Api.Endpoints;

public static class TaskListEndpoints
{
    public static void MapTaskListEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/task-list").WithTags("Task List");

        group.MapGet("/{taskListId:int}",
                async (int taskListId, IMediator mediator) =>
                {
                    var query = new GetTaskListByIdQuery(taskListId);
                    var response = await mediator.Send(query);
                    return Results.Ok(ApiResponse<GetTaskListByIdQueryResponse>.SuccessWithData(response));
                })
            .WithName("GetTaskListById")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapPost("/",
                async (CreateTaskListCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<CreateTaskListResponse>.SuccessWithData(response));
                })
            .WithName("CreateTaskList")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapPut("/",
                async (UpdateTaskListCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<UpdateTaskListResponse>.SuccessWithData(response));
                })
            .WithName("UpdateTaskList")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapDelete("/{taskListId}",
                async (int taskListId, IMediator mediator) =>
                {
                    var command = new DeleteTaskListCommand(taskListId);
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<DeleteTaskListResponse>.SuccessWithData(response));
                })
            .WithName("DeleteTaskList")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);

        // Items
        group.MapPost("/{taskListId}/items",
                async (CreateTaskListItemCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<CreateTaskListItemResponse>.SuccessWithData(response));
                })
            .WithName("CreateTaskListItem")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapPut("/{taskListId}/items",
                async (UpdateTaskListItemCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<UpdateTaskListItemResponse>.SuccessWithData(response));
                })
            .WithName("UpdateTaskListItem")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("/{taskListId}/items/{taskListItemId}",
                async (int taskListItemId, IMediator mediator) =>
                {
                    var command = new DeleteTaskListItemCommand(taskListItemId);
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<DeleteTaskListItemResponse>.SuccessWithData(response));
                })
            .WithName("DeleteTaskListItem")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{taskListId}/items/reorder",
                async (ReorderTaskListItemCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<ReorderTaskListItemResponse>.SuccessWithData(response));
                })
            .WithName("ReorderTaskListItem")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);

        group.MapPut("/{taskListId}/items/status",
                async (UpdateTaskListItemCompletedStatusCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<UpdateTaskListItemCompletedStatusResponse>.SuccessWithData(response));
                })
            .WithName("UpdateCompletedStatus")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);

        // Invitations
        group.MapPost("/{taskListId}/invite",
                async (int taskListId, InviteUserCommand command, IMediator mediator) =>
                {
                    var inviteCommand = new InviteUserCommand
                    {
                        InvitedUserEmail = command.InvitedUserEmail,
                        TaskListId = taskListId
                    };

                    var result = await mediator.Send(inviteCommand);
                    return result
                        ? Results.Ok(ApiResponse<string>.SuccessWithMessage("Invitation sent successfully."))
                        : Results.BadRequest(ApiResponse<string>.FailureWithMessage("Failed to send invitation."));
                })
            .WithName("InviteUser")
            .RequireAuthorization()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status403Forbidden)
            .Produces(StatusCodes.Status404NotFound);

        // group.MapPost("/invitations/{token}/accept",
        //         async (string token, IMediator mediator) =>
        //         {
        //             var command = new AcceptInviteCommand(token);
        //             var result = await mediator.Send(command);
        //             return result
        //                 ? Results.Ok(ApiResponse<string>.SuccessWithMessage("Invitation accepted successfully."))
        //                 : Results.BadRequest(ApiResponse<string>.FailureWithMessage("Failed to accept invitation."));
        //         })
        //     .WithName("AcceptInvitation")
        //     .RequireAuthorization()
        //     .Produces(StatusCodes.Status400BadRequest)
        //     .Produces(StatusCodes.Status200OK)
        //     .Produces(StatusCodes.Status403Forbidden)
        //     .Produces(StatusCodes.Status404NotFound);
        //
        // group.MapPost("/invitations/{token}/decline",
        //         async (string token, IMediator mediator) =>
        //         {
        //             var command = new DeclineInviteCommand(token);
        //             var result = await mediator.Send(command);
        //             return result
        //                 ? Results.Ok(ApiResponse<string>.SuccessWithMessage("Invitation declined successfully."))
        //                 : Results.BadRequest(ApiResponse<string>.FailureWithMessage("Failed to decline invitation."));
        //         })
        //     .WithName("DeclineInvitation")
        //     .RequireAuthorization()
        //     .Produces(StatusCodes.Status400BadRequest)
        //     .Produces(StatusCodes.Status200OK)
        //     .Produces(StatusCodes.Status403Forbidden)
        //     .Produces(StatusCodes.Status404NotFound);
    }
}