using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PrettyRoad.DAL.Interface;

namespace PrettyRoad.DAL;

public class Finder<T> : IFinder<T> where T : class
{
    private readonly DbSet<T> _set;

    public Finder(PrettyRoadDbContext context)
    {
        _set = context.Set<T>();
    }
    
    public async Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellation = default) //possible null and thats OK
    {
        return await _set.FindAsync(expression, cancellation);
    }

    public T Find(Expression<Func<T, bool>> expression) //possible null and thats OK
    {
        return _set.Find(expression);
    }
}