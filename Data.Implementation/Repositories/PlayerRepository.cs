using Data.Abstract;
using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation.Repositories
{
    internal class PlayerRepository : Repository<int, Player>, IPlayerRepository
    {
        private readonly NFSContext _context;

        private DbSet<Player> _dbSet;

        public PlayerRepository(NFSContext context) : base(context)
        {
            _context = context;

            _dbSet = context.Set<Player>();
        }
    }
}