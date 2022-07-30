using System.Linq.Expressions;

namespace PrettyRoad.DAL.Interface;

public interface IReadOnlyRepository<T> where T : class
{
    Task<T[]> ToArrayAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    Task<T[]> ToArrayAsync(CancellationToken cancellationToken = default);
    Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
}    
