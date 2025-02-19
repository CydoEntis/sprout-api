using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Auth.Commands.Login;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;


namespace TaskGarden.Application.Features.Passwords.Commands.ForgotPassword;

public record ForgotPasswordCommand(string Email) : IRequest<ForgotPasswordResponse>;

public class ForgotPasswordResponse : BaseResponse;

public class ForgotPasswordCommandHandler(
    UserManager<AppUser> userManager,
    IEmailTemplateService emailTemplateService,
    IEmailService emailService)
    : IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>
{
    public async Task<ForgotPasswordResponse> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null)
            throw new NotFoundException(ExceptionMessages.UserNotFound);
        var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
        var encodedToken = Uri.EscapeDataString(resetToken);
        var resetUrl = $"{ProjectConsts.DevUrl}/reset-password?token={encodedToken}";
        var placeholders = new Dictionary<string, string>
        {
            { "Recipient's Email", request.Email },
            { "Reset Link", resetUrl }
        };

        var emailBody = emailTemplateService.GetEmailTemplate("ForgotPasswordTemplate", placeholders);
        await emailService.SendEmailAsync("TaskGarden", request.Email, "Forgot Password Request",
            emailBody);

        return new ForgotPasswordResponse()
            { Message = "If an account with that email exists, a password reset link will be sent." };
    }
}