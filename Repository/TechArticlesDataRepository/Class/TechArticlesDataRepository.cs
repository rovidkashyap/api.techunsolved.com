using api.techsunolved.com.Repository.BaseRepository.Class;
using api.techunsolved.com.Data;
using api.techunsolved.com.Repository.TechArticlesDataRepository.Interface;
using api.techunsolved.com.TechContext;
using Microsoft.EntityFrameworkCore;

namespace api.techunsolved.com.Repository.TechArticlesDataRepository.Class
{
    public class TechArticlesDataRepository : BaseRepository<TechArticlesData>, ITechArticlesDataRepository
    {
        private readonly DataContext _context;
        public TechArticlesDataRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TechArticlesData>> GetAllIncludeTechArticles()
        {
            return await _context.techArticlesData.Include(x => x.TechArticles).ToListAsync();
        }

        public async Task<IEnumerable<TechArticlesData>> GetDataIncludeTechArticlesById(int Id)
        {
            return await _context.techArticlesData.Include(x => x.TechArticles).Where(x => x.TechArticlesId == Id || x.TechArticlesDataId == Id).ToListAsync();
        }
    }
}
