using api.techunsolved.com.Repository.BaseRepository.Interface;
using api.techunsolved.com.TechContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace api.techsunolved.com.Repository.BaseRepository.Class
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _context;
        private DbSet<T> _dbSet;

        public BaseRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> CreateAsync(T Obj)
        {
            _dbSet.Add(Obj);
            await _context.SaveChangesAsync();

            return Obj;
        }

        public async Task<bool> DeleteAsync(T Obj)
        {
            _dbSet.Remove(Obj);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AsNoTracking().Where(filter).FirstOrDefaultAsync();
        }

        public async Task<int> GetCount(Expression<Func<T, bool>> filter)
        {
            int result = await _dbSet.AsNoTracking().Where(filter).CountAsync();
            return result;
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AsNoTracking().Where(filter).ToListAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsNoTracking().Where(filter);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T> UpdateAsync(T Obj)
        {
            _dbSet.Update(Obj);
            await _context.SaveChangesAsync();

            return Obj;
        }
    }
}
