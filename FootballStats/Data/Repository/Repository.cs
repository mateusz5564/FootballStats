using FootballStats.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballStats.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public event EventHandler<T> ItemAdded;
        public event EventHandler<T> ItemRemoved;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Add(T entity)
        {
            ItemAdded?.Invoke(this, entity);
            _dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            ItemRemoved?.Invoke(this, entity);
            _dbSet.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
