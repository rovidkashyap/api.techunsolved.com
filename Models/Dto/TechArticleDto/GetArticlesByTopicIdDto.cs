using api.techunsolved.com.Data;

namespace api.techunsolved.com.Models.Dto.TechArticleDto
{
    public class GetArticlesByTopicIdDto
    {
        public int techArticleId { get; set; }
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
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
