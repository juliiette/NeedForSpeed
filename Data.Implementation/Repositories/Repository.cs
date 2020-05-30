using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return _dbSet.AsNoTracking().ToList();
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
            /*var saved = false;
            try
            {
                // Attempt to save changes to the database
                _dbSet.Update(item);
                _context.SaveChanges();
                saved = true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Detail)
                    {
                        var proposedValues = entry.CurrentValues;
                        var databaseValues = entry.GetDatabaseValues();

                        foreach (var property in proposedValues.Properties)
                        {
                            var proposedValue = proposedValues[property];
                            var databaseValue = databaseValues[property];

                            // TODO: decide which value should be written to database
                            proposedValues[property] = proposedValue;
                        }

                        // Refresh original values to bypass next concurrency check
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                   
                }
            }*/
            _dbSet.Update(item);
            _context.SaveChanges();
        }
    }
}