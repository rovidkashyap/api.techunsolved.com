using api.techunsolved.com.Data;
using api.techunsolved.com.Repository.BaseRepository.Interface;

namespace api.techunsolved.com.Repository.TechSubCategoryRepository.Interface
{
    public interface ITechSubCategoryRepository : IBaseRepository<TechSubcategory>
    {
        Task<IEnumerable<TechSubcategory>> GetAllIncludeTechCategoryAsync();
        Task<IEnumerable<TechSubcategory>> GetAllIncludeTechCategoryAsync(int id);
        Task<IEnumerable<TechSubcategory>> GetSubCategoryByIdAsync(int id);
        Task<IEnumerable<TechSubcategory>> GetByTechSubcategoryInitialAsync(string initial);
        Task<int> GetSubCategoryCount(string categoryInitial);
    }
}
