using MediatR;
using TaskGarden.Infrastructure.Models;

namespace TaskGarden.Api.Application.Features.Auth.Commands.ResetPassword;

public static class ResetPasswordEndpoint
{
    public static void MapResetPasswordEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/auth/reset-password", async (ResetPasswordCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(ApiResponse<ResetPasswordResponse>.SuccessWithData(response));
            })
            .WithName("ResetPassword")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK);
    }
}