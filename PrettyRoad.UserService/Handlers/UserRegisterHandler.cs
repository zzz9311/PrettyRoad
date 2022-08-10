using MediatR;
using PrettyRoad.UserService.Requests;

namespace PrettyRoad.UserService.Handlers;

public class UserRegisterHandler : IRequestHandler<UserRegisterRequest, IResult>
{
    public async Task<IResult> Handle(UserRegisterRequest request, CancellationToken cancellationToken)
    {
        //BLL LOGIC OR JUST GET BLL FROM DI AND USE IT
        await Task.Delay(10, cancellationToken);
        return Results.Ok(new { message = request.Login });
    }
}