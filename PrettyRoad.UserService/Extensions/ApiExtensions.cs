using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrettyRoad.UserService.Requests;

namespace PrettyRoad.UserService.Extensions;

public static class ApiExtensions
{
    public static void MediatePost<TRequest>(this WebApplication app, string path, CancellationToken cancellationToken = default)
        where TRequest : IGeneralHttpRequest
    {
        app.MapPost(path, async (IMediator mediator, [FromBody] TRequest request) =>
        {
            await mediator.Send(request, cancellationToken);
        });
    }
    
    public static void MediateGet<TRequest>(this WebApplication app, string path, CancellationToken cancellationToken = default)
        where TRequest : IGeneralHttpRequest
    {
        app.MapGet(path, async (IMediator mediator, [FromQuery] TRequest request) =>
        {
            await mediator.Send(request, cancellationToken);
        });
    }
}