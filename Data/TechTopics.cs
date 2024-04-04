using api.techunsolved.com.Data.Common;

namespace api.techunsolved.com.Data
{

    public class TechTopics : AuditableBaseEntity
    {
        public int TechTopicId { get; set; }
        public string TechTopicName { get; set; }
        public string Level { get; set; }

        public int? TechModulesId { get; set; }
        public virtual TechModules techModules { get; set; }

        public virtual ICollection<TechArticles> techArticle { get; set; }
    }
}
