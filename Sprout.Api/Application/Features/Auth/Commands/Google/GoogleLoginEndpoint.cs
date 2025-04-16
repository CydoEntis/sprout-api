using MediatR;
using Sprout.Api.Application.Shared.Models;

namespace Sprout.Api.Application.Features.Auth.Commands.Google;

public static class GoogleLoginEndpoint
{
    public static void MapGoogleLoginEndpoint(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/api/auth/google-login", async (GoogleLoginCommand command, IMediator mediator) =>
        {
            var response = await mediator.Send(command);
            return Results.Ok(ApiResponse<GoogleLoginResponse>.SuccessWithData(response));
        })
        .WithName("GoogleLogin")
        .WithTags("Auth")
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status200OK);;
    }
}