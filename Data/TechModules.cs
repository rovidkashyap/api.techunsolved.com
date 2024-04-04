using api.techunsolved.com.Data.Common;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace api.techunsolved.com.Data
{
#nullable disable
    public class TechModules : AuditableBaseEntity
    {
        public int TechModulesId { get; set; }
        public string TechModulesName { get; set; }
        public string Description { get; set; }
        public string Initial { get; set; }

        public int? TechSubcategoryId { get; set; }
        public virtual TechSubcategory TechSubCategories { get; set; }

        public virtual ICollection<TechTopics> techTopic { get; set; }
    }
}
