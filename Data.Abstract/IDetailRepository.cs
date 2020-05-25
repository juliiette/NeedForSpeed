using Data.Entity;

namespace Data.Abstract
{
    public interface IDetailRepository : IRepository<int, Detail>
    {
    }
}