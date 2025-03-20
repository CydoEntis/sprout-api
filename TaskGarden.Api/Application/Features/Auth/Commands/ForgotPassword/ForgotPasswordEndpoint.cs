using MediatR;
using TaskGarden.Api.Application.Shared.Models;

namespace TaskGarden.Api.Application.Features.Auth.Commands.ForgotPassword;

public static class ForgotPasswordEndpoint
{
    public static void MapForgotPasswordEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/auth/forgot-password", async (ForgotPasswordCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<ForgotPasswordResponse>.SuccessWithData(response));
            })
            .WithName("ForgotPassword")
            .WithTags("Auth")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK);
    }
}