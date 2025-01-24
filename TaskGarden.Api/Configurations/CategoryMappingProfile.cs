using AutoMapper;
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
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.CategoryTag, opt => opt.MapFrom(src => src.Tag))
            .ReverseMap();
        CreateMap<Category, CategoryWithCountResponseDto>().ReverseMap();
        CreateMap<CategoryWithCount, CategoryResponseDto>().ReverseMap();
        CreateMap<CategoryWithCount, CategoryWithCountResponseDto>().ReverseMap();

    }
}