using Data.Abstract;
using Data.Entity;

namespace Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NFSContext _context;


        public UnitOfWork(IRepository<Detail> detailRepository, IRepository<Car> carRepository,
            IRepository<Player> playerRepository, NFSContext context)
        {
            _context = context;

            DetailRepository = detailRepository;

            CarRepository = carRepository;

            PlayerRepository = playerRepository;
        }

        public IRepository<Detail> DetailRepository { get; }

        public IRepository<Car> CarRepository { get; }

        public IRepository<Player> PlayerRepository { get; }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}