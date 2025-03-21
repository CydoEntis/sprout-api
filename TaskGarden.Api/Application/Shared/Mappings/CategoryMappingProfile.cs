using AutoMapper;
using TaskGarden.Api.Application.Features.Categories.Commands.CreateCategory;
using TaskGarden.Api.Application.Features.Categories.Commands.UpdateCategory;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;
using TaskGarden.Api.Domain.Entities;


namespace TaskGarden.Api.Application.Shared.Mappings;



public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CreateCategoryCommand, Category>().ReverseMap();
        CreateMap<Category, GetAllCategoriesQueryResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag))
            .ReverseMap();

        CreateMap<Category, GetAllCategoriesQueryResponse>()
            .ForMember(src => src.TaskListCount, opt => opt.MapFrom(src => src.TaskLists.Count()))
            .ReverseMap();
        
        CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
        CreateMap<Category, UpdateCategoryResponse>().ReverseMap();
    }
}