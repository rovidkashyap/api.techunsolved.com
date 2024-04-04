using api.techunsolved.com.Data.Common;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace api.techunsolved.com.Data
{
    public class TechArticles : AuditableBaseEntity
    {
        public int TechArticleId { get; set; }
        public string? main_Heading { get; set; }
        public string? main_subHeading { get; set; }
        public string? intro_Heading { get; set; }
        public string? intro_Data { get; set; }
        public string? content_Heading { get; set; }
        public string? content_Data { get; set; }
        public string? example_content { get; set; }
        public string? output_content { get; set; }
        public string? conclusion_data { get; set; }
        public string? other_Content { get; set; }
        public int? techTopicId { get; set; }
        public virtual TechTopics? techTopic { get; set; }

        public virtual ICollection<TechArticlesData> techArticlesData { get; set; }
    }
}
