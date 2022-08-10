using System.Runtime.CompilerServices;

namespace PrettyRoad.UserService.Requests;

public class UserRegisterRequest : IGeneralHttpRequest
{
    public string Login { get; init; }
    public string Password { get; init; }
} 