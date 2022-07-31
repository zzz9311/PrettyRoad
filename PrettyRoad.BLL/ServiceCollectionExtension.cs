using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PrettyRoad.Core.DI;

namespace PrettyRoad.BLL;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBLL(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSelfRegistered(Assembly.GetExecutingAssembly());

        return serviceCollection;
    }
}