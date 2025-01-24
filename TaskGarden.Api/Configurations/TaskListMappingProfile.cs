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
            .ForMember(dest => dest.TotalTasksCount, opt => opt.MapFrom(src => src.TaskListItems.Count))
            .ForMember(dest => dest.CompletedTasksCount,
                opt => opt.MapFrom(src => src.TaskListItems.Count(t => t.IsCompleted)))
            .ForMember(dest => dest.TaskCompletionPercentage, opt => opt.MapFrom(src =>
                src.TaskListItems.Any()
                    ? (double)src.TaskListItems.Count(t => t.IsCompleted) / src.TaskListItems.Count() * 100
                    : 0))
            .ForMember(dest => dest.Members, opt => opt.MapFrom(src =>
                src.UserTaskLists.Select(utl => new MemberResponseDto
                {
                    UserId = utl.User.Id,
                    Name = $"{utl.User.FirstName} {utl.User.LastName}"
                }).ToList())).ReverseMap();


        CreateMap<UserTaskList, MemberResponseDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
                $"{src.User.FirstName} {src.User.LastName}"));
    }
}