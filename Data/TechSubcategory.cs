using api.techunsolved.com.Data.Common;

namespace api.techunsolved.com.Data
{
#nullable disable
    public class TechSubcategory : AuditableBaseEntity
    {
        public int TechSubcategoryId { get; set; }
        public string TechSubcategoryName { get; set; }
        public string Description { get; set; }
        public string Initial { get; set; }

        public int? TechCategoryId { get; set; }
        public virtual TechCategory TechCategory { get; set; }

        public virtual ICollection<TechModules> techModules { get; set; }
    }
}
