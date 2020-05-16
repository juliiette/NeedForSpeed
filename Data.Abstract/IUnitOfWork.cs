using Data.Entity;

namespace Data.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<Detail> DetailRepository { get; }
        
        IRepository<Car> CarRepository { get; }
        
        IRepository<Player> PlayerRepository { get; }

        void Save();
    }
}