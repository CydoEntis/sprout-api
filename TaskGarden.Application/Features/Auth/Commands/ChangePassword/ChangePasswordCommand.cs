using MediatR;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;

namespace TaskGarden.Application.Features.Auth.Commands.ChangePassword;

public record ChangePasswordCommand(string CurrentPassword, string NewPassword) : IRequest<ChangePasswordResponse>;

public class ChangePasswordResponse : BaseResponse;

public class ChangePasswordCommandHandler(
    IUserContextService userContextService,
    IUserService userService,
    IValidationService validationService
)
    : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
{
    public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetAuthenticatedUserId();

        var user = await userService.GetUserByIdAsync(userId);

        await validationService.ValidateRequestAsync(request, cancellationToken);
        await userService.ValidateCurrentPasswordAsync(user, request.CurrentPassword);

        await userService.ChangeUserPasswordAsync(user, request.CurrentPassword, request.NewPassword);

        return new ChangePasswordResponse { Message = "Password has been changed." };
    }
}