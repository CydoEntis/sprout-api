using AutoMapper;
using TaskGarden.Api.Dtos;
using TaskGarden.Api.Dtos.Auth;
using TaskGarden.Api.Dtos.Category;
using TaskGarden.Api.Dtos.TaskList;
using TaskGarden.Data.Models;

namespace TaskGarden.Api.Configurations;

public class TaskListMappingProfile : Profile
{
    public TaskListMappingProfile()
    {
        CreateMap<NewTaskListRequestDto, TaskList>().ReverseMap();
        CreateMap<NewTaskListResponseDto, TaskList>().ReverseMap();
        CreateMap<TaskListResponseDto, TaskList>().ReverseMap();
        CreateMap<NewTaskListRequestDto, TaskList>().ReverseMap();

        CreateMap<TaskList, TaskListResponseDto>()
            .ForMember(dest => dest.Members, opt => opt.MapFrom(src =>
                src.UserTaskLists.Select(utl => new MemberResponseDto
                {
                    UserId = utl.User.Id,
                    Name = $"{utl.User.FirstName} {utl.User.LastName}"
                }).ToList()));

        CreateMap<UserTaskList, MemberResponseDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
                $"{src.User.FirstName} {src.User.LastName}"));
        
        CreateMap<TaskList, TaskListResponseDto>()
            .ForMember(dest => dest.TaskListItems, opt => opt.MapFrom(src => src.TaskListItems ?? new List<TaskListItem>()))
            .ReverseMap();
    }
}