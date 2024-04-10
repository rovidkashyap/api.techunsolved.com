using api.techunsolved.com.Data;
using api.techunsolved.com.Repository.BaseRepository.Interface;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace api.techunsolved.com.Repository.TechInterviewQuestionsRepository.Interface
{
    public interface ITechInterviewQuestionsRepository : IBaseRepository<TechInterview_Questions>
    {
        Task<IEnumerable<TechInterview_Questions>> GetAllQuestionsIncludeModulesName();
        Task<int> GetQuestionsCountByModules(string modulesName);
    }
}
