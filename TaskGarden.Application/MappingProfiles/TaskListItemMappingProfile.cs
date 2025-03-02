using AutoMapper;
using TaskGarden.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Features.TaskList.Commands.CreateTaskList;
using TaskGarden.Application.Features.TaskList.Commands.UpdateTaskList;
using TaskGarden.Application.Features.TaskList.Queries.GetTaskListById;
using TaskGarden.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Application.MappingProfiles;

public class TaskListItemMappingProfile : Profile
{
    public TaskListItemMappingProfile()
    {
        CreateMap<CreateTaskListItemCommand, TaskListItem>();
        CreateMap<TaskListItemDetail, TaskListItemResponse>();
    }
}