using api.techunsolved.com.Data.Common;

namespace api.techunsolved.com.Data
{
#nullable disable
    public class TechCategory : AuditableBaseEntity
    {
        public int TechCategoryId { get; set; }
        public string TechCategoryName { get; set; }
        public string Description { get; set; }
        public string Initial { get; set; }

        public virtual ICollection<TechSubcategory> TechSubCategories { get; set; }

    }
}
