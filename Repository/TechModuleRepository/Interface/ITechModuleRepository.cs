using api.techunsolved.com.Data;
using api.techunsolved.com.Repository.BaseRepository.Interface;

namespace api.techunsolved.com.Repository.TechModuleRepository.Interface
{
    public interface ITechModuleRepository : IBaseRepository<TechModules>
    {
        Task<IEnumerable<TechModules>> GetAllIncludeSubCategoryAsync();
        Task<IEnumerable<TechModules>> GetAllIncludeSubCategoryAsync(int id);
        Task<IEnumerable<TechModules>> GetModulesBySubCatIdAndModuleIdAsync(int Id);
        Task<int> GetAllModulesCount();
        Task<IEnumerable<TechModules>> GetModulesByInitial(string initial);
        Task<int> GetCountBySubCatId(int subCatId);
        Task<int> GetCountBySubCatName(string subCatName);
    }
}
