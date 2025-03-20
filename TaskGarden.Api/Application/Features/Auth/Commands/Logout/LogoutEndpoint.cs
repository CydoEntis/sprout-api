using MediatR;
using TaskGarden.Infrastructure.Models;

namespace TaskGarden.Api.Application.Features.Auth.Commands.Logout;

public static class LogoutEndpoint
{
    public static void MapLogoutEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/auth/logout", async (IMediator mediator) =>
            {
                var response = await mediator.Send(new LogoutCommand());
                return Results.Ok(ApiResponse<LogoutResponse>.SuccessWithData(response));
            })
            .WithName("Logout")
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status200OK);
    }
}