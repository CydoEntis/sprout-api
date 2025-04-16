using Sprout.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using Sprout.Api.Application.Features.TaskListItem.Commands.CreateTaskListItems;
using Sprout.Api.Application.Features.TaskListItem.Commands.DeleteTaskListItem;
using Sprout.Api.Application.Features.TaskListItem.Commands.ReorderTaskListItem;
using Sprout.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItem;
using Sprout.Api.Application.Features.TaskListItem.Commands.UpdateTaskListItemCompletedStatus;
using Sprout.Api.Application.Features.TaskListItem.Queries.GetDueForTheWeek;
using Sprout.Api.Application.Features.TaskListItem.Queries.GetDueToday;
using Sprout.Api.Application.Features.TasklistItem.Queries.GetTaskListItems;

namespace Sprout.Api.Application.Features.TaskListItem;

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