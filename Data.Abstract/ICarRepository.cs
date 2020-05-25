using Data.Entity;

namespace Data.Abstract
{
    public interface ICarRepository : IRepository<int, Car>
    {
    }
}