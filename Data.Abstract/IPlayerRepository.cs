using Data.Entity;

namespace Data.Abstract
{
    public interface IPlayerRepository : IRepository<int, Player>
    {
    }
}