using api.techsunolved.com.Repository.BaseRepository.Class;
using api.techunsolved.com.Data;
using api.techunsolved.com.Repository.TechTopicRepository.Interface;
using api.techunsolved.com.TechContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.techunsolved.com.Repository.TechTopicRepository.Class
{
    public class TechTopicRepository : BaseRepository<TechTopics>, ITechTopicRepository
    {
        private readonly DataContext _context;

        public TechTopicRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TechTopics>> GetAllIncludeTechModules(int page, int pageSize)
        {
            return await _context.techTopics.Include(x => x.techModules).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<TechTopics> GetTopicIncludeModules(int id)
        {
            return await _context.techTopics.Include(x => x.techModules).Where(x => x.TechTopicId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TechTopics>> GetTopicsByLevelAndModuleId(string level, string moduleName)
        {
            return await _context.techTopics.Include(x => x.techModules).Where(x => x.Level == level && x.techModules.TechModulesName == moduleName).ToListAsync();
        }

        public async Task<IEnumerable<TechTopics>> GetTopicsIncludeModulesByModuleName(string moduleName)
        {
            return await _context.techTopics.Include(x => x.techModules).Where(x => x.techModules.TechModulesName == moduleName).ToListAsync();
        }

        public async Task<IEnumerable<TechTopics>> GetTopicsIncludeModulesByInitial(string initial)
        {
            return await _context.techTopics.Include(x => x.techModules).Where(x => x.techModules.Initial == initial).ToListAsync();
        }

        public async Task<IEnumerable<TechTopics>> GetTopicsByModuleIdAndTopicIdAsync(int Id)
        {
            return await _context.techTopics.Include(x => x.techModules).Where(x => x.TechModulesId == Id || x.TechTopicId == Id).ToListAsync();
        }

        public async Task<IEnumerable<TechTopics>> GetAllIncludeModules()
        {
            return await _context.techTopics.Include(x => x.techModules).ToListAsync();
        }
    }
}
