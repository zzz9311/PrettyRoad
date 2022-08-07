using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PrettyRoad.BLL.Users;
using PrettyRoad.Core.DI;
using PrettyRoad.DAL.Entities;

namespace PrettyRoad.BLL;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBLL(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSelfRegistered(Assembly.GetExecutingAssembly());

        serviceCollection.AddAutoMapper(typeof(UserMapper).Assembly);   
        
        return serviceCollection;
    }
}