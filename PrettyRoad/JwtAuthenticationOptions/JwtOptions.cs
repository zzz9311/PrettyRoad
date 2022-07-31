using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PrettyRoad.JwtAuthenticationOptions;

public static class JwtOptions
{
    public static string Issuer { get; } = "Authentication";
    public static string Audience { get; } = "PrettyRoad";
    private static string JwtKey { get; } = "isdjfhposuidhfpiosudhfpiusdfhpsdiu";
    public static int TokenLifeTime { get; set; } = 10;
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtKey));
    }
}