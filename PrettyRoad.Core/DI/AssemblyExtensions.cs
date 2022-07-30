using System.Reflection;

namespace PrettyRoad.Core.DI;

public static class AssemblyExtensions
{
    public static IEnumerable<InjectionDIElements> GetGenericTypesOf(
        this Assembly assembly,
        Type serviceType)
    {
        return assembly
            .GetTypes()
            .SelectMany(
                t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == serviceType)
                    .Select(i => new InjectionDIElements
                    {
                        Implementation = t,
                        TypeParameters = i.GetGenericArguments().ToArray(),
                        Service = i
                    }));
    }
}