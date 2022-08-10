using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrettyRoad.Core.DI;
using PrettyRoad.DAL.DbConfigures;
using PrettyRoad.DAL.Interface;

namespace PrettyRoad.DAL;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDAL(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDbConfigure>(x =>
        {
            var configuration = x.GetService<IConfiguration>();
            var connectionString = configuration["Connection_string"];
            return new DbConfigure(connectionString);
        });

        serviceCollection.AddDbContext<PrettyRoadDbContext>();

        serviceCollection.AddSelfRegistered(Assembly.GetExecutingAssembly());

        serviceCollection.AddScoped(typeof(IFinder<>), typeof(Finder<>));
        serviceCollection.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        serviceCollection.AddScoped<IUnitOfWork>(provider => provider.GetService<PrettyRoadDbContext>());
        return serviceCollection;
    }
}