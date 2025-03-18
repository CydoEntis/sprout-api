using FluentValidation;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskGarden.Api.Infrastructure.Services.Interfaces;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Exceptions;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Api.Application.Features.Auth.Commands.Google;

public record GoogleLoginCommand(string AuthorizationCode) : IRequest<GoogleLoginResponse>;

public class GoogleLoginResponse : BaseResponse
{
    public string AccessToken { get; init; } = string.Empty;
}

public class GoogleLoginCommandHandler
    : IRequestHandler<GoogleLoginCommand, GoogleLoginResponse>
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly ISessionService _sessionService;
    private readonly ICookieService _cookieService;
    private readonly IValidator<GoogleLoginCommand> _validator;

    public GoogleLoginCommandHandler(IConfiguration configuration, UserManager<AppUser> userManager,
        ITokenService tokenService, ISessionService sessionService, ICookieService cookieService,
        IValidator<GoogleLoginCommand> validator)
    {
        _configuration = configuration;
        _userManager = userManager;
        _tokenService = tokenService;
        _sessionService = sessionService;
        _validator = validator;
        _cookieService = cookieService;
    }

    public async Task<GoogleLoginResponse> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var googleUserInfo = await ExtractUserInfoFromAuthCodeAsync(request.AuthorizationCode)
                             ?? throw new InvalidTokenException("Invalid Google token");

        var user = await _userManager.FindByEmailAsync(googleUserInfo.Email) ??
                   await CreateUserFromGoogleInfoAsync(googleUserInfo);

        var accessToken = await GenerateAndStoreTokensAsync(user!);

        return new GoogleLoginResponse { Message = "Logged in successfully", AccessToken = accessToken };
    }

    private async Task<AppUser?> CreateUserFromGoogleInfoAsync(GoogleUserInfo googleUserInfo)
    {
        var newUser = new AppUser
        {
            UserName = googleUserInfo.Email,
            Email = googleUserInfo.Email,
            FirstName = googleUserInfo.FirstName,
            LastName = googleUserInfo.LastName
        };

        var result = await _userManager.CreateAsync(newUser);
        return result.Succeeded ? newUser : null;
    }

    private async Task<string> GenerateAndStoreTokensAsync(AppUser user)
    {
        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        var session = await _sessionService.CreateSessionAsync(user.Id, refreshToken);

        _cookieService.Append(CookieConsts.RefreshToken, refreshToken.Token, httpOnly: true, refreshToken.ExpiryDate);
        _cookieService.Append(CookieConsts.SessionId, session.SessionId, httpOnly: true, refreshToken.ExpiryDate);

        return accessToken;
    }

    private async Task<GoogleUserInfo?> ExtractUserInfoFromAuthCodeAsync(string authoCode)
    {
        try
        {
            var clientId = _configuration["Authentication:Google:ClientId"];
            var clientSecret = _configuration["Authentication:Google:ClientSecret"];

            var redirectUri = "postmessage";

            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                }
            });

            var tokenResponse = await flow.ExchangeCodeForTokenAsync(
                "user",
                authoCode,
                redirectUri,
                CancellationToken.None);

            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenResponse.IdToken);

            return new GoogleUserInfo
            {
                Email = payload.Email,
                FirstName = payload.GivenName,
                LastName = payload.FamilyName,
                GoogleId = payload.Subject
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error exchanging token: {ex.Message}");
            return null;
        }
    }
}