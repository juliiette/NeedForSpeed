using System.Collections.Generic;

namespace Data.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Create(TEntity item);

        void Delete(TEntity item);

        void Update(TEntity item);
    }
}