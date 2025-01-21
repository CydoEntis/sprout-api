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
    }
}