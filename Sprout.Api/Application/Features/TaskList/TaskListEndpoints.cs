using Sprout.Api.Application.Features.TaskList.Commands.CreateTaskList;
using Sprout.Api.Application.Features.TaskList.Commands.CreateTaskListWithCategory;
using Sprout.Api.Application.Features.TaskList.Commands.DeleteTaskList;
using Sprout.Api.Application.Features.Tasklist.Commands.FavoriteTasklist;
using Sprout.Api.Application.Features.TaskList.Commands.UpdateTaskList;
using Sprout.Api.Application.Features.TaskList.Queries.GetFavorited;
using Sprout.Api.Application.Features.TaskList.Queries.GetTaskListById;


namespace Sprout.Api.Application.Features.TaskList;

public static class TaskListEndpoints
{
    public static void MapTaskListEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapCreateTaskListEndpoint();
        routes.MapUpdateTaskListEndpoint();
        routes.MapDeleteTaskListEndpoint();
        routes.MapCreateTaskListWithCategoryEndpoint();
        routes.MapGetTaskListByIdEndpoint();
        routes.MapFavoriteTasklistEndpoint();
        routes.MapGetFavoritedTaskListsEndpoints();
    }
}