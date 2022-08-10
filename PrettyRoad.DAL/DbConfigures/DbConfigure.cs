using Microsoft.EntityFrameworkCore;

namespace PrettyRoad.DAL.DbConfigures;

public class DbConfigure : IDbConfigure
{
    private readonly string _connectionString;

    public DbConfigure(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Configure(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}