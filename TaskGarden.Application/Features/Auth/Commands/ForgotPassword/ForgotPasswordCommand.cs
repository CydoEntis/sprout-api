using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.Features.Auth.Commands.ForgotPassword;

public record ForgotPasswordCommand(string Email) : IRequest<ForgotPasswordResponse>;

public class ForgotPasswordResponse : BaseResponse;

public class ForgotPasswordCommandHandler(
    IUserService userService,
    IEmailTemplateService emailTemplateService,
    IEmailService emailService)
    : IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>
{
    public async Task<ForgotPasswordResponse> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userService.GetUserByEmailAsync(request.Email);
        if (user is null)
        {
            return new ForgotPasswordResponse
            {
                Message = "If an account with that email exists, a password reset link will be sent."
            };
        }

        var resetUrl = await GeneratePasswordResetUrl(user);
        await SendForgotPasswordEmail(request.Email, resetUrl);

        return new ForgotPasswordResponse
        {
            Message = "If an account with that email exists, a password reset link will be sent."
        };
    }

    private async Task<string> GeneratePasswordResetUrl(AppUser user)
    {
        var resetToken = await userService.GeneratePasswordResetTokenAsync(user);
        var encodedToken = Uri.EscapeDataString(resetToken);
        return $"{ProjectConsts.DevUrl}/reset-password?token={encodedToken}";
    }

    private async Task SendForgotPasswordEmail(string email, string resetUrl)
    {
        var placeholders = new Dictionary<string, string>
        {
            { "Recipient's Email", email },
            { "Reset Link", resetUrl }
        };

        var emailBody = emailTemplateService.GetEmailTemplate("ForgotPasswordTemplate", placeholders);
        await emailService.SendEmailAsync("TaskGarden", email, "Forgot Password Request", emailBody);
    }
}