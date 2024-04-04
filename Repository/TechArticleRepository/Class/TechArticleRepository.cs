using api.techsunolved.com.Repository.BaseRepository.Class;
using api.techunsolved.com.Data;
using api.techunsolved.com.Repository.TechArticleRepository.Interface;
using api.techunsolved.com.TechContext;
using Microsoft.EntityFrameworkCore;

namespace api.techunsolved.com.Repository.TechArticleRepository.Class
{
    public class TechArticleRepository : BaseRepository<TechArticles>, ITechArticleRepository
    {
        private readonly DataContext _context;

        public TechArticleRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TechArticles>> GetAllIncludeTechTopics()
        {
            return await _context.techArticles.Include(x => x.techTopic).ToListAsync();
        }

        public async Task<TechArticles> GetSingleArticleIncludeTechTopicById(int id)
        {
            return await _context.techArticles.Include(x => x.techTopic).Where(x => x.TechArticleId == id).FirstOrDefaultAsync();
        }
    }
}
