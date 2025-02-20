using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Features.Auth.Commands.ResetPassword;

public record ResetPasswordCommand(string Email, string Token, string NewPassword) : IRequest<ResetPasswordResponse>;

public class ResetPasswordResponse : BaseResponse;

public class ResetPasswordCommandHandler(UserManager<AppUser> userManager)
    : IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
{
    public async Task<ResetPasswordResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
            throw new NotFoundException(ExceptionMessages.UserNotFound);

        var decodedToken = Uri.UnescapeDataString(request.Token);

        var tokenIsValid = await userManager.VerifyUserTokenAsync(
            user,
            userManager.Options.Tokens.PasswordResetTokenProvider,
            "ResetPassword",
            decodedToken
        );

        if (!tokenIsValid)
            throw new InvalidTokenException(ExceptionMessages.TokenInvalid);

        var currentPasswordHash = user.PasswordHash;
        var passwordHasher = new PasswordHasher<AppUser>();
        var passwordVerificationResult =
            passwordHasher.VerifyHashedPassword(user, currentPasswordHash, request.NewPassword);

        if (passwordVerificationResult == PasswordVerificationResult.Success)
            throw new AlreadyExistsException("new-password", ExceptionMessages.OldPassword);

        var resetPasswordResult = await userManager.ResetPasswordAsync(user, decodedToken, request.NewPassword);
        if (!resetPasswordResult.Succeeded)
            throw new OperationException(ExceptionTitles.PasswordResetException,
                ExceptionMessages.PasswordResetFailed);

        return new ResetPasswordResponse() { Message = "Password has been reset." };
    }
}