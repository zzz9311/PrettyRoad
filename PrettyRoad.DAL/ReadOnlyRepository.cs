using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PrettyRoad.DAL.Interface;

namespace PrettyRoad.DAL;

public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class
{
    private readonly DbSet<T> _set;

    public ReadOnlyRepository(PrettyRoadDbContext context)
    {
        _set = context.Set<T>();
    }

    public async Task<T[]> ToArrayAsync(Expression<Func<T, bool>> expression,
        CancellationToken cancellationToken = default)
    {
        return await _set.Where(expression).ToArrayAsync(cancellationToken);
    }

    public async Task<T[]> ToArrayAsync(CancellationToken cancellationToken = default)
    {
        return await _set.ToArrayAsync(cancellationToken);
    }

    public async Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _set.FirstOrDefaultAsync(expression, cancellationToken);
    }
}