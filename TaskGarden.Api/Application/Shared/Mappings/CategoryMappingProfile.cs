using AutoMapper;
using TaskGarden.Api.Application.Features.Categories.Commands.CreateCategory;
using TaskGarden.Api.Application.Features.Categories.Commands.UpdateCategory;
using TaskGarden.Api.Application.Features.Categories.Queries;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using TaskGarden.Api.Application.Features.Invitation.Commands.AcceptInvite;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Api.Domain.Entities;


namespace TaskGarden.Api.Application.Shared.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CreateCategoryCommand, Category>().ReverseMap();
        CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
        CreateMap<Category, UpdateCategoryResponse>().ReverseMap();

        CreateMap<Category, GetAllCategoriesResponse>();
        CreateMap<Category, CategoryInfo>();

        CreateMap<NewCategoryCommand, Category>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
            .ForMember(dest => dest.UserId, opt => opt.Ignore());
    }
}