using Microsoft.EntityFrameworkCore;
using Data.Entity;

namespace Data.Implementation
{
    public class NFSContext : DbContext
    {
        public DbSet<Detail> Details { get; set; }
        
        public DbSet<Car> Cars { get; set; }
        
        public DbSet<Player> Players { get; set; }

        
        public NFSContext(DbContextOptions<NFSContext> options)
        {
            Database.EnsureCreated();
        }

        public NFSContext() : base () { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NFSDb;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.Entity<Detail>().ToTable("Details");

            model.Entity<Detail>().HasData(
                new Detail
                {
                    Id = 12,
                    Name = "Basic motor",
                    DetailType = DetailType.Motor,
                    RetailCost = 230,
                    RepairCost = 120,
                    Stability = 0.6,
                },
                new Detail
                {
                    Id = 223,
                    Name = "Avarege Motor MT-20",
                    DetailType = DetailType.Motor,
                    RetailCost = 290,
                    RepairCost = 150,
                    Stability = 0.72,
                },
                new Detail
                {
                    Id = 32,
                    Name = "Gold Rim",
                    DetailType = DetailType.Rim,
                    RetailCost = 280,
                    RepairCost = 200,
                    Stability = 0.9,
                },
                new Detail
                {
                    Id = 5,
                    Name = "Poor Battery YM-49",
                    DetailType = DetailType.Battery,
                    RetailCost = 80,
                    RepairCost = 120,
                    Stability = 0.5,
                }
                );
        }
    }
}