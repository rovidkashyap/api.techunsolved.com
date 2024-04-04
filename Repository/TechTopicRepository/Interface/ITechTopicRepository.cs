using AutoMapper.Configuration.Conventions;
using api.techunsolved.com.Data;
using api.techunsolved.com.Repository.BaseRepository.Interface;

namespace api.techunsolved.com.Repository.TechTopicRepository.Interface
{
    public interface ITechTopicRepository : IBaseRepository<TechTopics>
    {
        Task<IEnumerable<TechTopics>> GetAllIncludeModules();
        Task<IEnumerable<TechTopics>> GetAllIncludeTechModules(int page, int pageSize);
        Task<TechTopics> GetTopicIncludeModules(int id);
        Task<IEnumerable<TechTopics>> GetTopicsByLevelAndModuleId(string level, string moduleName);
        Task<IEnumerable<TechTopics>> GetTopicsIncludeModulesByModuleName(string moduleName);
        Task<IEnumerable<TechTopics>> GetTopicsIncludeModulesByInitial(string initial);
        Task<IEnumerable<TechTopics>> GetTopicsByModuleIdAndTopicIdAsync(int moduleId);
    }
}
