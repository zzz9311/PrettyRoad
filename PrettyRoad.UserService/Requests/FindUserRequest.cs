using PrettyRoad.UserService.Extensions;
using PrettyRoad.UserService.Helpers;

namespace PrettyRoad.UserService.Requests;

public class FindUserRequest : IGeneralHttpRequest//StandardGetRequest<FindUserRequest>
{
    public string ID { get; set; }
    
    public override string ToString() => $"({ID})";
    
    public static FindUserRequest Parse(string value, IFormatProvider? provider)
    {
        if (!TryParse(value, provider, out var result))
        {
            throw new ArgumentException("Could not parse supplied value.", nameof(value));
        }
    
        return result;
    }
    
    public static bool TryParse(string? path, IFormatProvider? provider, out FindUserRequest? model)
    {
        model = null;
        var result = QueryClassBuilder<FindUserRequest>.CreateObjectFromQuery(path);
        
        if (result != null)
        {
            model = result;
            return true;
        }
        
        return false;
    }
}