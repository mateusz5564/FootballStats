using FootballStats.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballStats.Data
{
    public class FootballStatsDbContext : DbContext
    {
        public DbSet<Footballer> Footballers => Set<Footballer>();
        public DbSet<Coach> Coaches => Set<Coach>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=footballStats;Trusted_Connection=True;");
        }
    }
}
