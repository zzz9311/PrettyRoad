using Microsoft.EntityFrameworkCore;

namespace PrettyRoad.DAL.DbConfigures;

public interface IDbConfigure
{
    public void Configure(DbContextOptionsBuilder optionsBuilder);
}