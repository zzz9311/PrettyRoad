using System.ComponentModel.Design;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace PrettyRoad.Core.DI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSelfRegistered(this IServiceCollection serviceCollection, Assembly assembly)
    {
        foreach (var el in assembly.GetGenericTypesOf(typeof(ISelfRegistered<>)))
        {
            serviceCollection.AddScoped(el.TypeParameters[0], el.Implementation);
        }

        return serviceCollection;
    }
}