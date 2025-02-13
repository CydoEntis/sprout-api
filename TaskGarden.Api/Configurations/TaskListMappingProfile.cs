using AutoMapper;
using TaskGarden.Api.Dtos;
using TaskGarden.Api.Dtos.Auth;
using TaskGarden.Api.Dtos.Category;
using TaskGarden.Api.Dtos.TaskList;
using TaskGarden.Data.Models;
using TaskGarden.Data.Projections;

namespace TaskGarden.Api.Configurations;

public class TaskListMappingProfile : Profile
{
    public TaskListMappingProfile()
    {
        CreateMap<NewTaskListRequestDto, TaskList>().ReverseMap();
        CreateMap<NewTaskListResponseDto, TaskList>().ReverseMap();
        CreateMap<TaskListResponseDto, TaskList>().ReverseMap();
        CreateMap<NewTaskListRequestDto, TaskList>().ReverseMap();
        CreateMap<UpdateTaskListRequestDto, TaskList>().ReverseMap();
        
        CreateMap<TaskListDetails, TaskListDetailsResponseDto>().ReverseMap();
        CreateMap<TaskListOverview, TaskListResponseDto>().ReverseMap();
        CreateMap<TaskListAssignments, MemberResponseDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
                $"{src.User.FirstName} {src.User.LastName}"));
    }
}