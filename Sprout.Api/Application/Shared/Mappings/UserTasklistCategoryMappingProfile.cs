using AutoMapper;
using Sprout.Api.Application.Features.Categories.Queries.GetAllCategories;
using Sprout.Api.Application.Features.Categories.Queries.GetRecentCategories;
using Sprout.Api.Application.Shared.Projections;

namespace Sprout.Api.Application.Shared.Mappings;

public class UserTasklistCategoryMappingProfile : Profile
{
    public UserTasklistCategoryMappingProfile()
    {
        CreateMap<CategoryWithTasklistCount, GetRecentCategoriesQueryResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Category.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Category.Tag))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Category.Color));
    }
}