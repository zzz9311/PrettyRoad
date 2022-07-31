using System.Linq.Expressions;

namespace PrettyRoad.DAL.Interface;

public interface IFinder<T> where T : class
{
    ValueTask<T> FindAsync(object[] keys, CancellationToken cancellation = default);
    ValueTask<T> FindAsync(object key, CancellationToken cancellation = default);
    T Find(params object[] keys);
}