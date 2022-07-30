using System.Linq.Expressions;

namespace PrettyRoad.DAL.Interface;

public interface IFinder<T> where T : class
{
    Task<T> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellation = default);
    T Find(Expression<Func<T, bool>> expression);
}