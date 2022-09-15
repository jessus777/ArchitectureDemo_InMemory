using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    public static class Endpoints
    {
        public static WebApplication UseEndPoints(this WebApplication app)
        {
            app.MapPost("api/createUser",
                async ([FromBody] CreateUserCommand command, IMediator mediator, CancellationToken token) =>
                    Results.Ok(await mediator.Send(command, token)))
                .WithTags("Users");

            app.MapGet("api/getAllUsers",
                async (IMediator mediator, CancellationToken token) =>
                    Results.Ok(await mediator.Send(new GetAllUserQuery(), token)))
                .WithTags("Users");
            return app;
        }
    }
}
