﻿// using MediatR;
// using Microsoft.AspNetCore.Identity;
// using TaskGarden.Api.Constants;
// using TaskGarden.Application.Exceptions;
// using TaskGarden.Application.Features.Auth.Commands.Login;
// using TaskGarden.Application.Services.Contracts;
// using TaskGarden.Infrastructure.Entities;
// using TaskGarden.Infrastructure.Models;
//
// namespace TaskGarden.Application.Features.Tokens.Commands;
// public record RefreshTokensCommand : IRequest<RefreshTokensResponse>;
//
// public class RefreshTokensResponse : BaseResponse
// {
//     public string AccessToken { get; set; } = string.Empty;
// }
//
//
// public class RefreshTokensCommandHandler(
//     ICookieService cookieService,
//     ISessionService sessionService,
//     ITokenService tokenService,
//     UserManager<AppUser> userManager)
//     : IRequestHandler<RefreshTokensCommand, RefreshTokensResponse>
// {
//     public async Task<RefreshTokensResponse> Handle(RefreshTokensCommand request, CancellationToken cancellationToken)
//     {
//         var refreshToken = cookieService.Get(CookieConsts.RefreshToken);
//         if (string.IsNullOrEmpty(refreshToken))
//             throw new NotFoundException("Token not found");
//
//         var session = await sessionService.GetSessionAsync(refreshToken);
//         if (session == null)
//             throw new NotFoundException("Session not found");
//
//         var user = await userManager.FindByIdAsync(session.UserId);
//         if (user == null)
//             throw new NotFoundException("User not found");
//
//         var newAccessToken = tokenService.GenerateAccessToken(user);
//         var newRefreshToken = tokenService.GenerateRefreshToken();
//
//         await sessionService.InvalidateSessionAsync(session);
//         await sessionService.CreateSessionAsync(user.Id, newRefreshToken);
//         cookieService.Append(CookieConsts.RefreshToken, newRefreshToken.Token, true, newRefreshToken.ExpiryDate);
//
//         return new RefreshTokensResponse { Message = "Tokens refreshed successfully.", AccessToken = newAccessToken };
//     }
// }
