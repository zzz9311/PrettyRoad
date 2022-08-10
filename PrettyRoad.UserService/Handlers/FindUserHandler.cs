using MediatR;
using PrettyRoad.UserService.Requests;

namespace PrettyRoad.UserService.Handlers;

public class FindUserHandler: IRequestHandler<FindUserRequest, IResult>
{
    public async Task<IResult> Handle(FindUserRequest request, CancellationToken cancellationToken)
    {
        return Results.Ok(new { Name = "TEst", Login = "Login", request.ID });
    }
}