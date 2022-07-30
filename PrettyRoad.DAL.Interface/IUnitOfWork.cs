namespace PrettyRoad.DAL.Interface;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    void SaveChanges();
}