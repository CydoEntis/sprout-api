using AutoMapper;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;
using TaskGarden.Application.Projections;

namespace TaskGarden.Api.Application.Shared.Mappings;

public class UserTaskListCategoryMappingProfile : Profile
{
    public UserTaskListCategoryMappingProfile()
    {
        CreateMap<CategoryWithTaskListCount, GetRecentCategoriesQueryResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Category.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Category.Tag))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Category.Color));
    }
}