using api.techsunolved.com.Repository.BaseRepository.Class;
using api.techunsolved.com.Data;
using api.techunsolved.com.Repository.TechModuleRepository.Interface;
using api.techunsolved.com.TechContext;
using Microsoft.EntityFrameworkCore;

namespace api.techunsolved.com.Repository.TechModuleRepository.Class
{
    public class TechModuleRepository : BaseRepository<TechModules>, ITechModuleRepository
    {
        private readonly DataContext _context;
        public TechModuleRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TechModules>> GetAllIncludeSubCategoryAsync()
        {
            return await _context.techModules.Include(x => x.TechSubCategories).ToListAsync();
        }

        public async Task<IEnumerable<TechModules>> GetAllIncludeSubCategoryAsync(int id)
        {
            return await _context.techModules.Include(x => x.TechSubCategories).Where(x => x.TechModulesId == id).ToListAsync();
        }

        public async Task<IEnumerable<TechModules>> GetModulesBySubCatIdAndModuleIdAsync(int Id)
        {
            return await _context.techModules.Include(x => x.TechSubCategories).Where(x => x.TechSubcategoryId == Id || x.TechModulesId == Id).ToListAsync();
        }

        public async Task<int> GetAllModulesCount()
        {
            return await _context.techModules.CountAsync();
        }

        public async Task<int> GetCountBySubCatId(int subCatId)
        {
            return await _context.techModules.Where(x => x.TechSubcategoryId.Equals(subCatId)).CountAsync();
        }

        public async Task<int> GetCountBySubCatName(string subCatName)
        {
            return await _context.techModules.Where(x => x.TechSubCategories.TechSubcategoryName == subCatName).CountAsync();
        }

        public async Task<IEnumerable<TechModules>> GetModulesByInitial(string initial)
        {
            return await _context.techModules.Include(x => x.TechSubCategories).Where(x => x.TechSubCategories.Initial == initial).ToListAsync();
        }
    }
}
