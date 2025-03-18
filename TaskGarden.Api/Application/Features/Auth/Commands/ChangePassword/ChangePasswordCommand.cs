using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Api.Application.Features.Auth.Commands.ChangePassword;

public record ChangePasswordCommand(string CurrentPassword, string NewPassword) : IRequest<ChangePasswordResponse>;

public class ChangePasswordResponse : BaseResponse;

public class ChangePasswordCommandHandler
    : AuthRequiredHandler, IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IValidator<ChangePasswordCommand> _validator;

    public ChangePasswordCommandHandler(IHttpContextAccessor httpContextAccessor,
        UserManager<AppUser> userManager,
        IValidator<ChangePasswordCommand> validator
    ) : base(httpContextAccessor)
    {
        _userManager = userManager;
        _validator = validator;
    }

    public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var user = await GetUserByIdAsync();
        if (user is null)
            throw new NotFoundException("User not found.");


        if (!await CheckIfPasswordIsValidAsync(user, request.CurrentPassword))
            throw new BadRequestException("Invalid Password",
                "An invalid password was entered",
                "current-password",
                "Current password does not match.");

        if (!await ChangeUserPasswordAsync(user, request.CurrentPassword, request.NewPassword))
            throw new ResourceModificationException("Failed to change the password.");

        return new ChangePasswordResponse { Message = "Password has been changed." };
    }

    private async Task<AppUser?> GetUserByIdAsync()
    {
        var userId = GetAuthenticatedUserId();
        return await _userManager.FindByIdAsync(userId);
    }

    private async Task<bool> CheckIfPasswordIsValidAsync(AppUser? user, string currentPassword)
    {
        return await _userManager.CheckPasswordAsync(user, currentPassword);
    }

    private async Task<bool> ChangeUserPasswordAsync(AppUser? user, string currentPassword, string newPassword)
    {
        var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        return result.Succeeded;
    }
}