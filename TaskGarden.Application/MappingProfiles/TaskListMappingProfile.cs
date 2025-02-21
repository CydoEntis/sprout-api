using AutoMapper;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Features.TaskList.Commands.CreateTaskList;
using TaskGarden.Application.Features.TaskList.Commands.UpdateTaskList;
using TaskGarden.Application.Features.TaskList.Queries.GetTaskListById;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Projections;

namespace TaskGarden.Application.MappingProfiles;


public class TaskListMappingProfile : Profile
{
    public TaskListMappingProfile()
    {
        CreateMap<CreateTaskListCommand, TaskList>().ReverseMap();
        CreateMap<CreateTaskListResponse, TaskList>().ReverseMap();
        CreateMap<GetTaskListByIdQueryResponse, TaskList>().ReverseMap();
        CreateMap<CreateTaskListCommand, TaskList>().ReverseMap();
        CreateMap<UpdateTaskListCommand, TaskList>().ReverseMap();
        
        // CreateMap<TaskListDetails, TaskListDetailsResponseDto>().ReverseMap();
        // CreateMap<TaskListOverview, TaskListResponseDto>().ReverseMap();
        CreateMap<TaskListAssignments, MemberResponse>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
                $"{src.User.FirstName} {src.User.LastName}"));
    }
}