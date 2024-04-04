using api.techsunolved.com.Repository.BaseRepository.Class;
using api.techunsolved.com.Data;
using api.techunsolved.com.Repository.TechSubCategoryRepository.Interface;
using api.techunsolved.com.TechContext;
using Microsoft.EntityFrameworkCore;

namespace api.techunsolved.com.Repository.TechSubCategoryRepository.Class
{
    public class TechSubCategoryRepository : BaseRepository<TechSubcategory>, ITechSubCategoryRepository
    {
        private readonly DataContext _context;
        public TechSubCategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TechSubcategory>> GetAllIncludeTechCategoryAsync()
        {
            return await _context.techSubCategories.Include(x => x.TechCategory).ToListAsync();
        }

        public async Task<IEnumerable<TechSubcategory>> GetAllIncludeTechCategoryAsync(int id)
        {
            return await _context.techSubCategories.Include(x => x.TechCategory).Where(x => x.TechSubcategoryId == id).ToListAsync();
        }

        public async Task<IEnumerable<TechSubcategory>> GetSubCategoryByIdAsync(int id)
        {
            return await _context.techSubCategories.Include(x => x.TechCategory).Where(x => x.TechCategoryId == id || x.TechSubcategoryId == id).ToListAsync();
        }

        public async Task<IEnumerable<TechSubcategory>> GetByTechSubcategoryInitialAsync(string initial)
        {
            return await _context.techSubCategories.Include(x => x.TechCategory).Where(x => x.Initial == initial).ToListAsync();
        }

        public async Task<int> GetSubCategoryCount(string categoryInitial)
        {
            return await _context.techSubCategories.Include(x => x.TechCategory).Where(x => x.TechCategory.Initial == categoryInitial).CountAsync();
        }
    }
}
