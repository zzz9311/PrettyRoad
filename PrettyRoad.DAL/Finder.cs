using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PrettyRoad.Core.DI;
using PrettyRoad.DAL.Interface;

namespace PrettyRoad.DAL;

public class Finder<T> : IFinder<T> where T : class
{
    private readonly DbSet<T> _set;

    public Finder(PrettyRoadDbContext context)
    {
        _set = context.Set<T>();
    }
    
    
    public ValueTask<T> FindAsync(object key, CancellationToken cancellation = default) //possible null and thats OK
    {
        return _set.FindAsync(key);
    }

    public ValueTask<T> FindAsync(object[] keys, CancellationToken cancellationToken = default) //possible null and thats OK
    {
        return _set.FindAsync(keys);
    }

    public T Find(params object[] keys)
    {
        return _set.Find(keys);
    }
}