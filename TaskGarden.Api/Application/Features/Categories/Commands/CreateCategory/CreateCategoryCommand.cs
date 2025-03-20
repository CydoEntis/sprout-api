using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string Name, string Tag, string Color) : IRequest<CreateCategoryResponse>;

public class CreateCategoryResponse : BaseResponse
{
    public int CategoryId { get; set; }
}

public class CreateCategoryCommandHandler : AuthRequiredHandler,
    IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
{
    private readonly AppDbContext _context;
    private readonly IValidator<CreateCategoryCommand> _validator;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
        IValidator<CreateCategoryCommand> validator, IMapper mapper) : base(httpContextAccessor)
    {
        _context = context;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var userId = GetAuthenticatedUserId() ?? throw new UnauthorizedException("Invalid user");

        if (await CheckIfCategoryExistsAsync(userId, request.Name))
            throw new ConflictException($"Category with name {request.Name} already exists.");


        var category = _mapper.Map<Category>(request);
        category.UserId = userId!;

        var createdCategory = await CreateCategoryAsync(category);
        return new CreateCategoryResponse()
            { Message = $"{createdCategory.Name} category has been created", CategoryId = createdCategory.Id };
    }

    private async Task<bool> CheckIfCategoryExistsAsync(string categoryName, string userId)
    {
        var existingCategory = await _context.Categories
            .FirstOrDefaultAsync(c =>
                c.UserId == userId && c.Name.ToLower() == categoryName.ToLower());
        return existingCategory != null;
    }

    private async Task<Category> CreateCategoryAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }
}