using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Domain.Enums;
using TaskGarden.Infrastructure.Projections;
using TaskGarden.Infrastructure.Repositories;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Application.Shared.Handlers;
using TaskGarden.Api.Infrastructure.Services.Interfaces;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Infrastructure;

namespace TaskGarden.Api.Application.Features.Invitation.Commands.InviteUser;

public record InviteUserCommand : IRequest<bool>
{
    public string InvitedUserEmail { get; init; } = default!;
    public int TaskListId { get; init; }
}

public class InviteUserCommandHandler : AuthRequiredHandler, IRequestHandler<InviteUserCommand, bool>
{
    private readonly AppDbContext _context;
    private readonly IEmailService _emailService;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _configuration;

    private readonly string? _jwtSecret;


    public InviteUserCommandHandler(
        IHttpContextAccessor httpContextAccessor,
        AppDbContext context,
        IEmailService emailService,
        ITokenService tokenService,
        IUserService userService, IConfiguration configuration) : base(httpContextAccessor)
    {
        _context = context;
        _emailService = emailService;
        _tokenService = tokenService;
        _configuration = configuration;
        _jwtSecret = _configuration[JwtConsts.Secret];
    }

    public async Task<bool> Handle(InviteUserCommand request, CancellationToken cancellationToken)
    {
        if (await InviteExistsAsync(request.InvitedUserEmail, request.TaskListId))
            throw new ConflictException("An invitation already exists for this user.");

        var userId = GetAuthenticatedUserId();
        var user = await GetUserByIdAsync(userId);

        if (user == null)
            throw new NotFoundException("User not found.");


        var taskList = await GetTaskListDetailsById(request.TaskListId);
        if (taskList == null)
            throw new NotFoundException("Task list not found");

        var invitation = await CreateInviteAsync(taskList, request.InvitedUserEmail, user);
        if (invitation is null)
            throw new ResourceCreationException("Something went wrong while creating invite.");

        await SendInviteEmail(invitation, request.InvitedUserEmail);

        return true;
    }

    private async Task<bool> InviteExistsAsync(string email, int taskListId)
    {
        return await _context.Invitations
            .AnyAsync(i => i.InvitedUserEmail == email &&
                           i.TaskListId == taskListId &&
                           i.Status == InvitationStatus.Pending);
    }

    private async Task<AppUser?> GetUserByIdAsync(string userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    private async Task<TaskListPreview?> GetTaskListDetailsById(int id)
    {
        // Come back to this it can prob be improved by using the UserTaskListCategory table instead.
        return await _context.TaskLists
            .Where(q => q.Id == id)
            .Select(tl => new TaskListPreview()
            {
                Id = tl.Id,
                Name = tl.Name,
                Description = tl.Description,
                CategoryName = _context.UserTaskListCategories
                    .Where(utc => utc.TaskListId == tl.Id)
                    .Select(utc => utc.Category.Name)
                    .FirstOrDefault(),
                CompletedTasksCount = tl.TaskListItems.Count(q => q.IsCompleted),
                TotalTasksCount = tl.TaskListItems.Count(),
                IsCompleted = tl.IsCompleted,
                CreatedAt = tl.CreatedAt,
                Members = tl.TaskListMembers
                    .Select(tla => new Member
                    {
                        Id = tla.User.Id,
                        Name = tla.User.FirstName + " " + tla.User.LastName,
                    })
                    .ToList(),
                TaskListItems = tl.TaskListItems.OrderBy(q => q.Position).Select(q => new TaskListItemDetail
                {
                    Id = q.Id,
                    Description = q.Description,
                    IsCompleted = q.IsCompleted,
                    Position = q.Position,
                }).ToList(),
            })
            .FirstOrDefaultAsync();
    }

    private async Task<Domain.Entities.Invitation> CreateInviteAsync(TaskListPreview taskList, string recipientsEmail,
        AppUser inviter)
    {
        var invitation = new Domain.Entities.Invitation
        {
            TaskListId = taskList.Id,
            InvitedUserEmail = recipientsEmail,
            InviterUserId = inviter.Id,
            Token = GenerateInviteToken(inviter, taskList.Id, taskList.Name, taskList.CategoryName, taskList.Members),
            Status = InvitationStatus.Pending,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        };

        await _context.Invitations.AddAsync(invitation);

        await _context.SaveChangesAsync();
        return invitation;
    }

    private string GenerateInviteToken(AppUser inviter, int taskListId, string taskListName,
        string taskListCategoryName, List<Member> taskListMembers)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("inviter", $"{inviter.FirstName} {inviter.LastName}"),
            new Claim("inviterEmail", inviter.Email),
            new Claim("taskListName", taskListName),
            new Claim("taskListId", taskListId.ToString()),
            new Claim("category", taskListCategoryName),
            new Claim("inviteDate", DateTime.UtcNow.ToString("MM/dd/yyyy"))
        };

        var memberNames = taskListMembers.Select(m => m.Name).ToList();
        var membersJson = JsonConvert.SerializeObject(memberNames);
        claims.Add(new Claim("members", membersJson));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private async Task SendInviteEmail(Domain.Entities.Invitation invite, string recipientsEmail)
    {
        var inviteUrl = $"https://localhost:5173/invite/{invite.Token}";
        var placeholders = new Dictionary<string, string>
        {
            { "Recipient's Email", recipientsEmail },
            { "Invite Link", inviteUrl }
        };


        await _emailService.SendEmailAsync("Task Garden", recipientsEmail, "You’ve been invited!",
            "InviteUserTemplate", placeholders);
    }
}