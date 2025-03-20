using MediatR;
using TaskGarden.Infrastructure.Models;

namespace TaskGarden.Api.Application.Features.Auth.Commands.Google;

public static class GoogleLoginEndpoint
{
    public static void MapGoogleLoginEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/auth/google-login", async (GoogleLoginCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Ok(ApiResponse<GoogleLoginResponse>.SuccessWithData(response));
        });
    }
}