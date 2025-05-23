﻿using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Sprout.Api.Application.Shared.Constants;
using Sprout.Api.Application.Shared.Handlers;
using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Domain.Entities;
using Sprout.Api.Infrastructure.Services.Interfaces;
using Sprout.Application.Common.Constants;

namespace Sprout.Api.Application.Features.Auth.Commands.ForgotPassword;

public record ForgotPasswordCommand(string Email) : IRequest<ForgotPasswordResponse>;

public class ForgotPasswordResponse : BaseResponse;

public class ForgotPasswordCommandHandler : AuthRequiredHandler,
    IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly IValidator<ForgotPasswordCommand> _validator;

    public ForgotPasswordCommandHandler(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager,
        IEmailService emailService, IValidator<ForgotPasswordCommand> validator)
        : base(httpContextAccessor)
    {
        _userManager = userManager;
        _emailService = emailService;
        _validator = validator;
    }

    public async Task<ForgotPasswordResponse> Handle(ForgotPasswordCommand request,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }


        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
            return new ForgotPasswordResponse
            {
                Message = "If an account with that email exists, a password reset link will be sent."
            };

        var resetUrl = await GeneratePasswordResetUrl(user);
        await SendForgotPasswordEmail(request.Email, resetUrl);

        return new ForgotPasswordResponse
        {
            Message = "If an account with that email exists, a password reset link will be sent."
        };
    }

    private async Task<string> GeneratePasswordResetUrl(AppUser user)
    {
        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
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

        await _emailService.SendEmailAsync("Sprout", email, "Forgot Password Request", "ForgotPasswordTemplate",
            placeholders);
    }
}