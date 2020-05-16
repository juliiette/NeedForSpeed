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
    }
}