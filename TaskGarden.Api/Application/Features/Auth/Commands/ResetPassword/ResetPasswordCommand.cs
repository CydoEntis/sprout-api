using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Features.Auth.Commands.ResetPassword;

public record ResetPasswordCommand(string Email, string Token, string NewPassword) : IRequest<ResetPasswordResponse>;

public class ResetPasswordResponse : BaseResponse;

public class ResetPasswordCommandHandler : AuthRequiredHandler,
    IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IValidator<ResetPasswordCommand> _validator;

    public ResetPasswordCommandHandler(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager,
        IValidator<ResetPasswordCommand> validator) : base(httpContextAccessor)
    {
        _userManager = userManager;
        _validator = validator;
    }

    public async Task<ResetPasswordResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        var tokenIsValid = await VerifyPasswordResetTokenAsync(user, request.Token);
        if (!tokenIsValid)
            throw new InvalidTokenException(ExceptionMessages.TokenInvalid);

        var passwordVerificationResult = await VerifyPasswordAsync(user, request.NewPassword);
        if (passwordVerificationResult == PasswordVerificationResult.Success)
            throw new AlreadyExistsException("new-password", ExceptionMessages.OldPassword);

        var resetPasswordResult = await ResetPasswordAsync(user, request.Token, request.NewPassword);
        if (!resetPasswordResult.Succeeded)
            throw new OperationException(ExceptionTitles.PasswordResetException, ExceptionMessages.PasswordResetFailed);

        return new ResetPasswordResponse { Message = "Password has been reset." };
    }

    private async Task<bool> VerifyPasswordResetTokenAsync(AppUser user, string token)
    {
        var decodedToken = Uri.UnescapeDataString(token);
        return await _userManager.VerifyUserTokenAsync(
            user,
            _userManager.Options.Tokens.PasswordResetTokenProvider,
            "ResetPassword",
            decodedToken
        );
    }

    private async Task<PasswordVerificationResult> VerifyPasswordAsync(AppUser user, string password)
    {
        var passwordHasher = new PasswordHasher<AppUser>();
        return passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
    }

    private async Task<IdentityResult> ResetPasswordAsync(AppUser user, string token, string newPassword)
    {
        var decodedToken = Uri.UnescapeDataString(token);
        return await _userManager.ResetPasswordAsync(user, decodedToken, newPassword);
    }
}