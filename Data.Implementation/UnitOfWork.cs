using Data.Abstract;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NFSContext _context;

        public UnitOfWork(IRepository<int, Detail> detailRepository, IRepository<int, Car> carRepository,
            IRepository<int, Player> playerRepository, NFSContext context)
        {
            _context = context;

            DetailRepository = detailRepository;
            CarRepository = carRepository;
            PlayerRepository = playerRepository;
        }

        public IRepository<int, Detail> DetailRepository { get; }
        public IRepository<int, Car> CarRepository { get; }
        public IRepository<int, Player> PlayerRepository { get; }


        public void Save()
        {
            _context.SaveChanges();

            Detach();
        }

        private void Detach()
        {
            foreach (var entity in _context.ChangeTracker.Entries().ToArray())
                if (entity.Entity != null)
                    entity.State = EntityState.Detached;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}