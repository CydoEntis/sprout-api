﻿using AutoMapper;
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
        CreateMap<CategoryWithTaskLists, GetRecentCategoriesQueryResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Category.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Category.Tag))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Category.Color))
            .ForMember(dest => dest.RecentTaskLists, opt => opt.MapFrom(src => src.RecentlyUpdatedTaskLists));

        CreateMap<Category, CategoryWithTaskListCount>()
            .ForMember(dest => dest.TotalTaskLists, opt => opt.MapFrom(src => src.UserTaskListCategories.Count));

        CreateMap<List<CategoryWithTaskListCount>, GetCategoriesWithTaskListCountResponse>();


        CreateMap<CategoryWithTaskListCount, GetCategoriesWithTaskListCountResponse>();
        
    }
}