using Data.Entity;
using Data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation.Repositories
{
    class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly NFSContext _context;

        private DbSet<Car> _dbSet;

        public CarRepository(NFSContext context) : base(context)
        {
            _context = context;

            _dbSet = context.Set<Car>();
        }
    }
}
