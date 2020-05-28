using Data.Abstract;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NFSContext _context;

        public UnitOfWork(IDetailRepository detailRepository, ICarRepository carRepository,
            IPlayerRepository playerRepository, NFSContext context)
        {
            _context = context;

            DetailRepository = detailRepository;
            CarRepository = carRepository;
            PlayerRepository = playerRepository;
        }

        public IDetailRepository  DetailRepository { get; }
        public ICarRepository CarRepository { get; }
        public IPlayerRepository PlayerRepository { get; }


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