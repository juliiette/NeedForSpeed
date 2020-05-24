using Data.Abstract;
using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation.Repositories
{
    internal class DetailRepository : Repository<Detail>, IDetailRepository
    {
        private readonly NFSContext _context;

        private DbSet<Detail> _dbSet;

        public DetailRepository(NFSContext context) : base(context)
        {
            _context = context;

            _dbSet = context.Set<Detail>();
        }
    }
}