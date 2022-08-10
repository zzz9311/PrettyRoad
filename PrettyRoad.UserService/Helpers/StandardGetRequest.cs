using PrettyRoad.UserService.Extensions;
using PrettyRoad.UserService.Requests;

namespace PrettyRoad.UserService.Helpers;

public class StandardGetRequest<T> : IGeneralHttpRequest where T : class
{
    public static bool TryParse(string? path, out T model)
    {
        model = null;
        var result = QueryClassBuilder<T>.CreateObjectFromQuery(path);

        if (result != null)
        {
            model = result;
            return true;
        }
        
        return false;
    }
    public override string ToString() => nameof(T);
}