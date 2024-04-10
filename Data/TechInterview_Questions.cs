using api.techunsolved.com.Data.Common;

namespace api.techunsolved.com.Data
{
    public class TechInterview_Questions : AuditableBaseEntity
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string Level { get; set; }

        public int TechModulesId { get; set; }
        public virtual TechModules techModules { get; set; }
    }
}
