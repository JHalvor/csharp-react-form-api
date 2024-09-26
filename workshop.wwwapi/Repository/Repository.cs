using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using workshop.wwwapi.Data;

namespace workshop.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {


        private DataContext _db;
        private DbSet<T> _table = null;
        public Repository(DataContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }
       
        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions
                    .Aggregate<Expression<Func<T, object>>, IQueryable<T>>
                     (_table, (current, expression) => current.Include(expression));
            }
            return await _table.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }
        public async Task<T> GetById(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> Insert(T obj)
        {
            await _table.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }
        public async Task<T> Update(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
            return obj;
        }

        public async Task<T> Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
            return existing;
        }


        public Task Save()
        {
            return _db.SaveChangesAsync();
        }


    }
}
