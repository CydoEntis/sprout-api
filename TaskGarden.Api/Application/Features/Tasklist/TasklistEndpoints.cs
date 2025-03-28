using TaskGarden.Api.Application.Features.TaskList.Commands.CreateTaskList;
using TaskGarden.Api.Application.Features.TaskList.Commands.CreateTaskListWithCategory;
using TaskGarden.Api.Application.Features.TaskList.Commands.DeleteTaskList;
using TaskGarden.Api.Application.Features.TaskList.Commands.UpdateTaskList;
using TaskGarden.Api.Application.Features.TaskList.Queries.GetTaskListById;


namespace TaskGarden.Api.Application.Features.TaskList;

public static class TasklistEndpoints
{
    public static void MapTaskListEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapCreateTaskListEndpoint();
        routes.MapUpdateTaskListEndpoint();
        routes.MapDeleteTaskListEndpoint();
        routes.MapCreateTaskListWithCategoryEndpoint();
        routes.MapGetTaskListByIdEndpoint();
    }
}