using System.Runtime.InteropServices;
using System.Security.Claims;
using PrettyRoad.BLL.Users;
using PrettyRoad.Helpers;

namespace PrettyRoad.DI;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid ID =>
        Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("ID")).Value);
}