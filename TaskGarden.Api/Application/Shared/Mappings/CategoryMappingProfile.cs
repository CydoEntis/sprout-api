using AutoMapper;
using TaskGarden.Api.Application.Features.Categories.Commands.CreateCategory;
using TaskGarden.Api.Application.Features.Categories.Commands.UpdateCategory;
using TaskGarden.Api.Application.Features.Categories.Queries;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllCategories;
using TaskGarden.Api.Application.Features.Categories.Queries.GetAllTaskListsForCategory;
using TaskGarden.Api.Application.Features.Categories.Queries.GetCategoriesWithTaskTaskListCount;
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
    }
}