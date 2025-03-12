using MediatR;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure.Repositories;

namespace TaskGarden.Application.Features.Invitation.Commands.InviteUser;

public record InviteUserCommand : IRequest<bool>
{
    public string InvitedUserEmail { get; init; } = default!;
    public int TaskListId { get; init; }
}


public class InviteUserCommandHandler(
    IInvitationRepository invitationRepository,
    IEmailService emailService,
    IEmailTemplateService emailTemplateService)
    : IRequestHandler<InviteUserCommand, bool>
{
    public async Task<bool> Handle(InviteUserCommand request, CancellationToken cancellationToken)
    {
        if (await invitationRepository.InvitationExistsAsync(request.InvitedUserEmail, request.TaskListId))
        {
            throw new InvalidOperationException("An invitation already exists for this user.");
        }

        var invitation = new Domain.Entities.Invitation
        {
            TaskListId = request.TaskListId,
            InvitedUserEmail = request.InvitedUserEmail,
            Token = Guid.NewGuid().ToString(),
            Status = InvitationStatus.Pending,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        };

        await invitationRepository.AddAsync(invitation);

        var placeholders = new Dictionary<string, string>
        {
            { "InvitationToken", invitation.Token },
            { "TaskListId", request.TaskListId.ToString() }
        };

        var emailBody = emailTemplateService.GetEmailTemplate("InviteUserTemplate", placeholders);
        await emailService.SendEmailAsync("Task Garden", request.InvitedUserEmail, "You’ve been invited!", emailBody);

        return true;
    }
}