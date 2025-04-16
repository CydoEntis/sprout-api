using AutoMapper;
using FluentValidation;
using MediatR;
using Sprout.Api.Application.Shared.Extensions;
using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Domain.Entities;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Application.Common.Exceptions;
using Sprout.Infrastructure;

namespace Sprout.Api.Application.Features.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(int Id, string Name, string Tag, string Color) : IRequest<UpdateCategoryResponse>;

public class UpdateCategoryResponse : BaseResponse
{
    public int CategoryId { get; set; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryResponse>
{
    private readonly AppDbContext _context;
    private readonly IValidator<UpdateCategoryCommand> _validator;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(AppDbContext context,
        IValidator<UpdateCategoryCommand> validator, IMapper mapper)
    {
        _context = context;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<UpdateCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var category = await _context.Categories.GetByIdAsync(request.Id) ??
                       throw new NotFoundException("Category not found or access denied.");

        _mapper.Map(request, category);
        await UpdateCategoryAsync(category);
        return new UpdateCategoryResponse()
            { Message = $"{category.Name} category has been updated successfully", CategoryId = category.Id };
    }

    private async Task UpdateCategoryAsync(Category category)
    {
        _context.Update(category);
        await _context.SaveChangesAsync();
    }
}