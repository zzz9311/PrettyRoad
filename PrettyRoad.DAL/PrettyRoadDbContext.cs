using Microsoft.EntityFrameworkCore;
using PrettyRoad.DAL.Entities;
using PrettyRoad.DAL.Interface;

namespace PrettyRoad.DAL;

public class PrettyRoadDbContext : DbContext, IUnitOfWork
{
    // private IDbConfigure _dbConfigure;
    //
    // public PrettyRoadDbContext(IDbConfigure dbConfigure)
    // {
    //     _dbConfigure = dbConfigure;
    //     Database.Migrate();
    // }

    public PrettyRoadDbContext()
    {
        Database.Migrate();
    }

    public DbSet<User> Users { get; set; }

    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);
    }

    public void Save()
    {
        SaveChanges();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("");
        // _dbConfigure.Configure(optionsBuilder);
    }
}