using Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IRepository<TKey, TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(TKey id);

        void Create(TEntity item);

        void Delete(TEntity item);

        void Update(TEntity item);
    }
}