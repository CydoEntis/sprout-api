using AutoMapper;
using FluentValidation;
using MediatR;
using Sprout.Api.Application.Shared.Extensions;
using Sprout.Api.Application.Shared.Handlers;
using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Domain.Entities;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Application.Common.Exceptions;
using Sprout.Infrastructure;

namespace Sprout.Api.Application.Features.Categories.Commands.CreateCategory;

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

        if (await _context.Categories.CategoryExistsAsync(request.Name, userId))
            throw new ConflictException($"Category with name {request.Name} already exists.");


        var category = _mapper.Map<Category>(request);
        category.UserId = userId!;

        var createdCategory = await _context.CreateCategoryAsync(category);

        
        return new CreateCategoryResponse()
            { Message = $"{createdCategory.Name} category has been created", CategoryId = createdCategory.Id };
    }
}