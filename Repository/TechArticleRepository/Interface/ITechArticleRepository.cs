using api.techunsolved.com.Data;
using api.techunsolved.com.Repository.BaseRepository.Interface;

namespace api.techunsolved.com.Repository.TechArticleRepository.Interface
{
    public interface ITechArticleRepository : IBaseRepository<TechArticles>
    {
        Task<IEnumerable<TechArticles>> GetAllIncludeTechTopics();
        Task<TechArticles> GetSingleArticleIncludeTechTopicById(int id);
    }
}
