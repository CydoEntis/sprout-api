using TaskGarden.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.CreateTaskListItems;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.DeleteTaskListItem;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.ReorderTaskListItem;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItem;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItemCompletedStatus;
using TaskGarden.Api.Application.Features.TaskListItem.Queries.GetDueForTheWeek;
using TaskGarden.Api.Application.Features.TaskListItem.Queries.GetDueToday;
using TaskGarden.Api.Application.Features.TasklistItem.Queries.GetTaskListItems;

namespace TaskGarden.Api.Application.Features.TaskListItem;

public static class TaskListItemEndpoints
{
    public static void MapTaskListItemEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapCreateTaskListItemEndpoint();
        routes.MapCreateTaskListItemsEndpoint();
        routes.MapUpdateTaskListItemEndpoint();
        routes.MapDeleteTaskListItemEndpoint();
        routes.MapReorderTaskListItemEndpoint();
        routes.MapUpdateTaskListItemCompletedStatusEndpoint();
        routes.MapGetTasklistItemsEndpoint();
        routes.MapGetTaskListItemsPerCategoryByDateEndpoint();
        routes.MapGetTaskListItemsDueForTheWeekPerCategoryEndpoint();
    }
}