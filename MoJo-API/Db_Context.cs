using Microsoft.EntityFrameworkCore;

namespace MoJo_API
{
    class DataBase: DbContext
    {
        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {

        }
        public DbSet<building> buildings => Set<building>();
        public DbSet<room> rooms => Set<room>();
        public DbSet<storey> storeys => Set<storey>();


    }
}
