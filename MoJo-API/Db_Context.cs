using Microsoft.EntityFrameworkCore;

namespace MoJo_API
{
    class DataBase: DbContext
    {
        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {

        }
        public DbSet<Building> Buildings => Set<Building>();

    }
}
