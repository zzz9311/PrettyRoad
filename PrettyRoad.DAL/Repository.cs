using Microsoft.EntityFrameworkCore;
using PrettyRoad.DAL.Interface;

namespace PrettyRoad.DAL;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> _set;

    public Repository(PrettyRoadDbContext context)
    {
        _set = context.Set<T>();
    }

    public async Task InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _set.AddAsync(entity, cancellationToken);
    }

    public void Delete(T entity)
    {
        _set.Remove(entity);
    }
}