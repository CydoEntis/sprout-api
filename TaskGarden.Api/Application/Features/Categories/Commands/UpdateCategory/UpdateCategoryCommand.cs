﻿using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(int Id, string Name, string Tag, string Color) : IRequest<UpdateCategoryResponse>;

public class UpdateCategoryResponse : BaseResponse
{
    public int CategoryId { get; set; }
}

public class UpdateCategoryCommandHandler : AuthRequiredHandler,
    IRequestHandler<UpdateCategoryCommand, UpdateCategoryResponse>
{
    private readonly AppDbContext _context;
    private readonly IValidator<UpdateCategoryCommand> _validator;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(IHttpContextAccessor httpContextAccessor, AppDbContext context,
        IValidator<UpdateCategoryCommand> validator, IMapper mapper) : base(httpContextAccessor)
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

        var userId = GetAuthenticatedUserId();

        var category = await GetCategoryByIdAsync(userId, request.Id) ??
                       throw new NotFoundException("Category not found or access denied.");

        _mapper.Map(request, category);
        await UpdateCategoryAsync(category);
        return new UpdateCategoryResponse()
            { Message = $"{category.Name} category has been updated successfully", CategoryId = category.Id };
    }

    private async Task<Category?> GetCategoryByIdAsync(string userId, int categoryId)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == categoryId && c.UserId == userId);
    }

    private async Task UpdateCategoryAsync(Category category)
    {
        _context.Update(category);
        await _context.SaveChangesAsync();
    }
}