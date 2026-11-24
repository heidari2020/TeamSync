using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TeamSync.Api.Features.Auth.Login;

public static class LoginEndpoint
{
    public static void MapLoginEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/login", async (
            [FromBody] LoginCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var response = await mediator.Send(command, cancellationToken);
            return TypedResults.Ok(response);
        })
        .WithName("Login")
        .WithSummary("Authenticates a user and returns a JWT token")
        .WithTags("Auth");
    }
}