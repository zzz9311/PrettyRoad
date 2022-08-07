using System.Security.Claims;

namespace PrettyRoad.Helpers;

public static class ClaimsExtensions
{
    public static string GetUserID(this ClaimsIdentity clasims)
    {
        return clasims.Claims.SingleOrDefault(x => x.Type == "id")?.Value;
    }
}