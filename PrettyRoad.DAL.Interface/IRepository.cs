namespace PrettyRoad.DAL.Interface;

public interface IRepository<T> where T : class
{ 
    Task InsertAsync(T entity, CancellationToken cancellationToken = default);
    void Delete(T entity);
}