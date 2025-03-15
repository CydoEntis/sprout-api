using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.Auth.Commands.ResetPassword;

public record ResetPasswordCommand(string Email, string Token, string NewPassword) : IRequest<ResetPasswordResponse>;

public class ResetPasswordResponse : BaseResponse;

public class ResetPasswordCommandHandler(
    IUserService userService,
    IValidationService validationService
) : IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
{
    public async Task<ResetPasswordResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        await validationService.ValidateRequestAsync(request, cancellationToken);
        var user = await userService.GetUserByEmailAsync(request.Email);

        var tokenIsValid = await userService.VerifyPasswordResetTokenAsync(user, request.Token);
        if (!tokenIsValid)
            throw new InvalidTokenException(ExceptionMessages.TokenInvalid);

        var passwordVerificationResult = await userService.VerifyPasswordAsync(user, request.NewPassword);
        if (passwordVerificationResult == PasswordVerificationResult.Success)
            throw new AlreadyExistsException("new-password", ExceptionMessages.OldPassword);

        var resetPasswordResult = await userService.ResetPasswordAsync(user, request.Token, request.NewPassword);
        if (!resetPasswordResult.Succeeded)
            throw new OperationException(ExceptionTitles.PasswordResetException, ExceptionMessages.PasswordResetFailed);

        return new ResetPasswordResponse { Message = "Password has been reset." };
    }
}