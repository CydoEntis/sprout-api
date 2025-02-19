// using AutoMapper;
// using TaskGarden.Api.Dtos;
// using TaskGarden.Api.Dtos.Auth;
// using TaskGarden.Api.Dtos.Category;
// using TaskGarden.Infrastructure.Models;
//
// namespace TaskGarden.Api.Configurations;
//
// public class CategoryMappingProfile : Profile
// {
//     public CategoryMappingProfile()
//     {
//         CreateMap<NewCategoryRequestDto, Category>().ReverseMap();
//         CreateMap<Category, CategoryResponseDto>()
//             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
//             .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag))
//             .ReverseMap();
//
//         CreateMap<Category, CategoryOverviewResponseDto>()
//             .ForMember(src => src.TaskListCount, opt => opt.MapFrom(src => src.TaskLists.Count()))
//             .ReverseMap();
//         
//         CreateMap<UpdateCategoryRequestDto, Category>().ReverseMap();
//         CreateMap<Category, UpdateCategoryResponseDto>().ReverseMap();
//     }
// }