using CqrsTemplate.Data.Data.Repository;
using CqrsTemplate.Migrations;
using Microsoft.EntityFrameworkCore;

namespace CqrsTemplate.Infrastructure.Data.Repositories.Generic
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public void Delete(int id)
        {
            var entity = Get(id);

            if(!Equals(entity, null))
            {
                if(_context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }

                _dbSet.Remove(entity);
            }
        }

        public T Get(int id)
        {
            var entry = _dbSet.Find(id);

            return entry;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
