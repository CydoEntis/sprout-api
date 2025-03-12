using MediatR;
using Microsoft.Extensions.Configuration;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure.Repositories;

namespace TaskGarden.Application.Features.Invitation.Commands.InviteUser
{
    public record InviteUserCommand : IRequest<bool>
    {
        public string InvitedUserEmail { get; init; } = default!;
        public int TaskListId { get; init; }
    }

    public class InviteUserCommandHandler : IRequestHandler<InviteUserCommand, bool>
    {
        private readonly string _baseUrl;
        private readonly IInvitationRepository _invitationRepository;
        private readonly IEmailService _emailService;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IUserContextService _userContextService;

        public InviteUserCommandHandler(
            IInvitationRepository invitationRepository,
            IEmailService emailService,
            IEmailTemplateService emailTemplateService,
            IUserContextService userContextService,
            IConfiguration configuration)
        {
            _invitationRepository = invitationRepository;
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;
            _userContextService = userContextService;
            _baseUrl = configuration["AppUrl"];
        }

        public async Task<bool> Handle(InviteUserCommand request, CancellationToken cancellationToken)
        {
            var inviterUserId = _userContextService.GetUserId();

            if (await _invitationRepository.InvitationExistsAsync(request.InvitedUserEmail, request.TaskListId))
            {
                throw new InvalidOperationException("An invitation already exists for this user.");
            }

            var invitation = new Domain.Entities.Invitation
            {
                TaskListId = request.TaskListId,
                InvitedUserEmail = request.InvitedUserEmail,
                InviterUserId = inviterUserId,
                Token = Guid.NewGuid().ToString(),
                Status = InvitationStatus.Pending,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };

            await _invitationRepository.AddAsync(invitation);

            var acceptUrl = $"{_baseUrl}/api/task-list/invitations/{invitation.Token}/accept";
            var declineUrl = $"{_baseUrl}/api/task-list/invitations/{invitation.Token}/decline";

            var placeholders = new Dictionary<string, string>
            {
                { "Recipient's Email", request.InvitedUserEmail },
                { "Accept Invite Link", acceptUrl },
                { "Decline Invite Link", declineUrl }
            };

            var emailBody = _emailTemplateService.GetEmailTemplate("InviteUserTemplate", placeholders);
            await _emailService.SendEmailAsync("Task Garden", request.InvitedUserEmail, "You’ve been invited!",
                emailBody);

            return true;
        }
    }
}