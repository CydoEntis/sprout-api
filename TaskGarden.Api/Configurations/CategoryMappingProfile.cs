using AutoMapper;
using TaskGarden.Api.Dtos;
using TaskGarden.Api.Dtos.Auth;
using TaskGarden.Api.Dtos.Category;
using TaskGarden.Data.Models;

namespace TaskGarden.Api.Configurations;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<NewCategoryRequestDto, Category>().ReverseMap();
        CreateMap<Category, CategoryResponseDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag))
            .ReverseMap();

        CreateMap<Category, CategoriesTaskListsResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TaskLists.Select(t => t.Id)))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TaskLists.Select(t => t.Name)))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.TaskLists.Select(t => t.Description)))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
            .ForMember(dest => dest.TotalTasksCount, opt => opt.MapFrom(src =>
                src.TaskLists.SelectMany(tl => tl.TaskListItems).Count()))
            .ForMember(dest => dest.CompletedTasksCount, opt => opt.MapFrom(src =>
                src.TaskLists.SelectMany(tl => tl.TaskListItems).Count(t => t.IsCompleted)))
            .ForMember(dest => dest.TaskCompletionPercentage, opt => opt.MapFrom(src =>
                src.TaskLists.SelectMany(tl => tl.TaskListItems).Any()
                    ? (double)src.TaskLists.SelectMany(tl => tl.TaskListItems).Count(t => t.IsCompleted) /
                    src.TaskLists.SelectMany(tl => tl.TaskListItems).Count() * 100
                    : 0)) // Percentage of completed tasks
            .ForMember(dest => dest.Members, opt => opt.MapFrom(src =>
                src.TaskLists.SelectMany(tl => tl.TaskListAssignments)
                    .Select(utl => new MemberResponseDto
                    {
                        UserId = utl.User.Id,
                        Name = $"{utl.User.FirstName} {utl.User.LastName}"
                    }).ToList()))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new CategoryResponseDto
            {
                Id = src.Id,
                Name = src.Name,
                Tag = src.Tag
            }));

        // Mapping for TaskList to CategoriesTaskListsResponseDto (adjusted to get tasklist specific fields)
        CreateMap<TaskList, CategoriesTaskListsResponseDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)) // TaskList Name
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)) // TaskList Description
            .ForMember(dest => dest.Members, opt => opt.MapFrom(src =>
                src.TaskListAssignments.Select(utl => new MemberResponseDto
                {
                    UserId = utl.User.Id,
                    Name = $"{utl.User.FirstName} {utl.User.LastName}"
                }).ToList())) // Members of the task list
            .ForMember(dest => dest.TotalTasksCount, opt => opt.MapFrom(src =>
                src.TaskListItems.Count())) // Total tasks count for the task list
            .ForMember(dest => dest.CompletedTasksCount, opt => opt.MapFrom(src =>
                src.TaskListItems.Count(t => t.IsCompleted))) // Completed tasks count for the task list
            .ForMember(dest => dest.TaskCompletionPercentage, opt => opt.MapFrom(src =>
                src.TaskListItems.Any()
                    ? (double)src.TaskListItems.Count(t => t.IsCompleted) / src.TaskListItems.Count() * 100
                    : 0));

        CreateMap<Category, CategoryOverviewResponseDto>()
            .ForMember(src => src.TaskListCount, opt => opt.MapFrom(src => src.TaskLists.Count()))
            .ReverseMap();
        CreateMap<CategoryWithTaskListCount, CategoryResponseDto>().ReverseMap();
        CreateMap<CategoryWithTaskListCount, CategoryOverviewResponseDto>().ReverseMap();
    }
}