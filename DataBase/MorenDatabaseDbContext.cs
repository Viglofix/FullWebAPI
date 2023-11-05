using Microsoft.EntityFrameworkCore;
using DataBase.Models;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace DataBase
{
    public class MorenDatabaseDbContext : DbContext
    {
        public MorenDatabaseDbContext()
        {

        }
        public MorenDatabaseDbContext(DbContextOptions<MorenDatabaseDbContext> options) : base(options)
        {
          
        }
        public DbSet<MorenModelHeroes> morenherotable { get; set; }
        public DbSet<MorenModelLocations> morenlocationtable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("Server=localhost;database=MorenDataBase;User Id=viglofix;port=5432;Password=Hujbert12");
        }
    }
}
