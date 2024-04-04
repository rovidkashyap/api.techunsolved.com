using System.Linq.Expressions;

namespace api.techunsolved.com.Repository.BaseRepository.Interface
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        Task<T> CreateAsync(T Obj);
        Task<T> UpdateAsync(T Obj);
        Task<bool> DeleteAsync(T Obj);
        Task<int> GetCount(Expression<Func<T, bool>> filter);
    }
}
