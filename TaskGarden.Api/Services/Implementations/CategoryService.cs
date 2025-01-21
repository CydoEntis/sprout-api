using AutoMapper;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Data.Repositories.Contracts;

namespace TaskGarden.Api.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


}