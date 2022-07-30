using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using PrettyRoad.Core.DI;

namespace PrettyRoad.DAL;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDAL(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<PrettyRoadDbContext>();

        serviceCollection.AddSelfRegistered(Assembly.GetExecutingAssembly());

        return serviceCollection;
    }
}