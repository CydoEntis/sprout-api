using AutoMapper;
using Sprout.Api.Application.Features.Categories.Commands.CreateCategory;
using Sprout.Api.Application.Features.Categories.Commands.UpdateCategory;
using Sprout.Api.Application.Features.Categories.Queries;
using Sprout.Api.Application.Features.Categories.Queries.GetAllCategories;
using Sprout.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using Sprout.Api.Application.Features.Invitation.Commands.AcceptInvite;
using Sprout.Api.Application.Shared.Projections;
using Sprout.Api.Domain.Entities;


namespace Sprout.Api.Application.Shared.Mappings;

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