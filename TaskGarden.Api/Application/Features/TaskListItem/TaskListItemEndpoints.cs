using TaskGarden.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.DeleteTaskListItem;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.ReorderTaskListItem;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItem;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItemCompletedStatus;

namespace TaskGarden.Api.Application.Features.TaskListItem;

public static class TaskListItemEndpoints
{
    public static void MapTaskListItemEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapCreateTaskListItemEndpoint();
        routes.MapUpdateTaskListItemEndpoint();
        routes.MapDeleteTaskListItemEndpoint();
        routes.MapReorderTaskListItemEndpoint();
        routes.MapUpdateTaskListItemCompletedStatusEndpoint();
    }
}