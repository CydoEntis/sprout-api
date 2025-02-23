using MediatR;
using TaskGarden.Application.Features.Auth.Commands.ChangePassword;
using TaskGarden.Application.Features.Auth.Commands.ForgotPassword;
using TaskGarden.Application.Features.Auth.Commands.Login;
using TaskGarden.Application.Features.Auth.Commands.Logout;
using TaskGarden.Application.Features.Auth.Commands.RefreshTokens;
using TaskGarden.Application.Features.Auth.Commands.Register;
using TaskGarden.Application.Features.Auth.Commands.ResetPassword;
using TaskGarden.Infrastructure.Models;

namespace TaskGarden.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/auth").WithTags("Auth");

        group.MapPost("/register", async (RegisterCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<LoginResponse>.SuccessResponse(response));
            })
            .WithName("Register")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapPost("/login", async (LoginCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<LoginResponse>.SuccessResponse(response));
            })
            .WithName("Login")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK);

        group.MapPost("/refresh-tokens", async (RefreshTokensCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<RefreshTokensResponse>.SuccessResponse(response));
            })
            .WithName("RefreshTokens")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK);

        group.MapPost("/logout",
                async (IMediator mediator) =>
                {
                    var response = await mediator.Send(new LogoutCommand());
                    return Results.Ok(ApiResponse<LogoutResponse>.SuccessResponse(response));
                })
            .WithName("Logout")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK);

        group.MapPost("/forgot-password", async (ForgotPasswordCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<ForgotPasswordResponse>.SuccessResponse(response));
            })
            .WithName("ForgotPassword")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK);

        group.MapPost("/reset-password", async (ResetPasswordCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<ResetPasswordResponse>.SuccessResponse(response));
            })
            .WithName("ResetPassword")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK);

        group.MapPost("/change-password",
                async (ChangePasswordCommand command, IMediator mediator) =>
                {
                    var response = await mediator.Send(command);
                    return Results.Ok(ApiResponse<ChangePasswordResponse>.SuccessResponse(response));
                })
            .WithName("ChangePassword")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK);
    }
}