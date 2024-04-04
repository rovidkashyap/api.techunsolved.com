using api.techunsolved.com.Data;
using api.techunsolved.com.Repository.BaseRepository.Interface;

namespace api.techunsolved.com.Repository.TechArticlesDataRepository.Interface
{
    public interface ITechArticlesDataRepository : IBaseRepository<TechArticlesData>
    {
        Task<IEnumerable<TechArticlesData>> GetAllIncludeTechArticles();
        Task<IEnumerable<TechArticlesData>> GetDataIncludeTechArticlesById(int Id);
    }
}
