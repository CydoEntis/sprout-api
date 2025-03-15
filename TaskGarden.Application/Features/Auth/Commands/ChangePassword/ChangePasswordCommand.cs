using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Features.Auth.Commands.ChangePassword;

public record ChangePasswordCommand(string CurrentPassword, string NewPassword) : IRequest<ChangePasswordResponse>;

public class ChangePasswordResponse : BaseResponse;

public class ChangePasswordCommandHandler(UserManager<AppUser> userManager, IUserContextService userContextService)
    : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
{
    public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await GetUserAsync();

        ValidateCurrentPassword(user, request.CurrentPassword);

        await ChangeUserPassword(user, request.CurrentPassword, request.NewPassword);

        return new ChangePasswordResponse { Message = "Password has been changed." };
    }

    private async Task<AppUser> GetUserAsync()
    {
        var userId = userContextService.GetUserId() ?? throw new NotFoundException("User Id not found.");

        var user = await userManager.FindByIdAsync(userId);
        return user ?? throw new NotFoundException(ExceptionMessages.UserNotFound);
    }

    private async void ValidateCurrentPassword(AppUser user, string currentPassword)
    {
        var isValid = await userManager.CheckPasswordAsync(user, currentPassword);
        if (!isValid)
        {
            throw new BadRequestException(
                "Invalid Password",
                "An invalid password was entered",
                "current-password",
                ExceptionMessages.CurrentPasswordMismatch
            );
        }
    }

    private async Task ChangeUserPassword(AppUser user, string currentPassword, string newPassword)
    {
        var result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        if (!result.Succeeded)
        {
            throw new ResourceModificationException(ExceptionMessages.ChangePasswordFailed);
        }
    }
}