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

public class LogoutCommandHandler(UserManager<AppUser> userManager, IUserContextService userContextService)
    : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
{
    public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetUserId();

        if (userId == null)
            throw new NotFoundException("User Id not found.");

        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
            throw new NotFoundException(ExceptionMessages.UserNotFound);

        var isCurrentPasswordValid = await userManager.CheckPasswordAsync(user, request.CurrentPassword);
        if (!isCurrentPasswordValid)
            throw new ValidationException("current-password", ExceptionMessages.CurrentPasswordMismatch);

        var updateResult =
            await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!updateResult.Succeeded)
            throw new ResourceModificationException(ExceptionMessages.ChangePasswordFailed);

        return new ChangePasswordResponse() { Message = "Password has been changed." };
    }
}