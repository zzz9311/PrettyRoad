using Microsoft.EntityFrameworkCore;
using PrettyRoad.DAL.DbConfigures;
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

    public PrettyRoadDbContext():base()
    {
        Database.Migrate();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString: "");
        // _dbConfigure.Configure(optionsBuilder);
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);
    }

    public void Save()
    {
        try
        {
            SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public DbSet<User> Users { get; set; }
}