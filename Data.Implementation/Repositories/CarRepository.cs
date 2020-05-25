using Data.Abstract;
using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation.Repositories
{
    internal class CarRepository : Repository<int, Car>, ICarRepository
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