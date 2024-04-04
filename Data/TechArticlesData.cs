using api.techunsolved.com.Data.Common;

namespace api.techunsolved.com.Data
{
    public class TechArticlesData : AuditableBaseEntity
    {
        public int TechArticlesDataId { get; set; }
        public string? program_heading { get; set; }
        public string? program_code { get; set; }
        public string? output_heading { get; set; }
        public string? output_code { get; set; }
        public string? other_heading { get; set; }
        public string? other_code { get; set; }
        public int? TechArticlesId { get; set; }
        public virtual TechArticles? TechArticles { get; set; }
    }
}
