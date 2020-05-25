using System.Collections.Generic;
using System.Linq;
using Data.Abstract;
using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class Repository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : class
    {
        private readonly NFSContext _context;

        private readonly DbSet<TEntity> _dbSet;

        public Repository(NFSContext context)
        {
            _context = context;

            _dbSet = _context.Set<TEntity>();
        }


        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public TEntity GetById(TKey id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Delete(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _dbSet.Update(item);
            _context.SaveChanges();
        }
    }
}