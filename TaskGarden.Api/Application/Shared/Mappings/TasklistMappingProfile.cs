using AutoMapper;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using TaskGarden.Api.Application.Features.TaskList.Commands.CreateTaskList;
using TaskGarden.Api.Application.Features.TaskList.Commands.UpdateTaskList;
using TaskGarden.Api.Application.Features.TaskList.Queries.GetTaskListById;
// using TaskGarden.Api.Application.Features.TaskList.Queries.GetTaskListById;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.CreateTaskListItem;
using TaskGarden.Api.Application.Features.TaskListItem.Commands.ReorderTaskListItem;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Api.Application.Shared.Mappings;

public class TasklistMappingProfile : Profile
{
    public TasklistMappingProfile()
    {
        CreateMap<TaskList, TasklistInfo>()
            .ForMember(dest => dest.CategoryInfo, opt =>
                opt.MapFrom(src => src.UserCategories
                    .Select(utlc => utlc.Category)
                    .FirstOrDefault()))
            .ReverseMap();

        CreateMap<CreateTaskListCommand, TaskList>().ReverseMap();
        CreateMap<CreateTaskListResponse, TaskList>().ReverseMap();

        // CreateMap<GetTaskListByIdQueryResponse, TaskList>().ReverseMap();

        CreateMap<CreateTaskListCommand, TaskList>().ReverseMap();
        CreateMap<UpdateTaskListCommand, TaskList>()
            .ForMember(dest => dest.CreatedById, opt => opt.Ignore());

        CreateMap<TasklistInfo, GetAllTasklistsForCategoryResponse>().ReverseMap();
        // CreateMap<TaskListPreview, GetTaskListByIdQueryResponse>();
        CreateMap<TaskListMember, MemberResponse>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
                $"{src.User.FirstName} {src.User.LastName}"));


        // Task List Items
        CreateMap<CreateTasklistItemCommand, TaskListItem>();
        CreateMap<TasklistItemDetail, TasklistItemResponse>();
        CreateMap<ReorderTasklistItemCommand, TaskListItem>();
        CreateMap<TaskListItem, TasklistItemDetail>();
    }
}