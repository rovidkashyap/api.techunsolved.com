using api.techsunolved.com.Repository.BaseRepository.Class;
using api.techunsolved.com.Data;
using api.techunsolved.com.Repository.TechInterviewQuestionsRepository.Interface;
using api.techunsolved.com.TechContext;
using Microsoft.EntityFrameworkCore;

namespace api.techunsolved.com.Repository.TechInterviewQuestionsRepository.Class
{
    public class TechInterviewQuestionsRepository : BaseRepository<TechInterview_Questions>, ITechInterviewQuestionsRepository
    {
        private readonly DataContext _context;
        public TechInterviewQuestionsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TechInterview_Questions>> GetAllQuestionsIncludeModulesName()
        {
            return await _context.techInterviewQuestions.Include(x => x.techModules).ToListAsync();
        }

        public async Task<int> GetQuestionsCountByModules(string modulesName)
        {
            return await _context.techInterviewQuestions.Where(x => x.techModules.TechModulesName == modulesName).CountAsync();
        }
    }
}
