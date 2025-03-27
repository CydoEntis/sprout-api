using AutoMapper;
using TaskGarden.Api.Application.Features.Categories.Commands.CreateCategory;
using TaskGarden.Api.Application.Features.Categories.Commands.UpdateCategory;
using TaskGarden.Api.Application.Features.Categories.Queries;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using TaskGarden.Api.Application.Features.Categories.Queries.GetCategoriesWithTaskTaskListCount;
using TaskGarden.Api.Domain.Entities;


namespace TaskGarden.Api.Application.Shared.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        // Command to entity mappings
        CreateMap<CreateCategoryCommand, Category>().ReverseMap();
        CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
        CreateMap<Category, UpdateCategoryResponse>().ReverseMap();
        
        CreateMap<Category, GetAllCategoriesResponse>();
        
        // Query to response mappings
        CreateMap<CategoryWithTaskLists, GetRecentCategoriesQueryResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Category.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Category.Tag))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Category.Color))
            .ForMember(dest => dest.RecentTaskLists, opt => opt.MapFrom(src => src.RecentlyUpdatedTaskLists));

        // Category to CategoryWithTaskListCount mapping (including task list count)
        CreateMap<Category, CategoryWithTaskListCount>()
            .ForMember(dest => dest.TotalTaskLists, opt => opt.MapFrom(src => src.UserTaskListCategories.Count));

        // Fix the mapping for List<CategoryWithTaskListCount> to GetCategoriesWithTaskListCountResponse
        CreateMap<List<CategoryWithTaskListCount>, GetCategoriesWithTaskListCountResponse>();


        // If necessary, map individual CategoryWithTaskListCount to GetCategoriesWithTaskListCountResponse (this will be used if you need to map one at a time)
        CreateMap<CategoryWithTaskListCount, GetCategoriesWithTaskListCountResponse>();
        
    }
}