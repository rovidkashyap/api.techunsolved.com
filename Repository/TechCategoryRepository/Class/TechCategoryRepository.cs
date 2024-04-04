using api.techsunolved.com.Repository.BaseRepository.Class;
using api.techunsolved.com.Data;
using api.techunsolved.com.Repository.TechCategoryRepository.Interface;
using api.techunsolved.com.TechContext;

namespace api.techunsolved.com.Repository.TechCategoryRepository.Class
{
    public class TechCategoryRepository : BaseRepository<TechCategory>, ITechCategoryRepository
    {
        private readonly DataContext _context;
        public TechCategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
