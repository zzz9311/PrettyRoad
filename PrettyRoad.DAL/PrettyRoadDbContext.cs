using Microsoft.EntityFrameworkCore;
using PrettyRoad.DAL.Interface;

namespace PrettyRoad.DAL;

public class PrettyRoadDbContext : DbContext, IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);
    }

    public void SaveChanges()
    {
        base.SaveChanges();
    }
}