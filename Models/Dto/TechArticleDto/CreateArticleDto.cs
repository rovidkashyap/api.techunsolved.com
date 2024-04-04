using api.techunsolved.com.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace api.techunsolved.com.Models.Dto.TechArticleDto
{
    public class CreateArticleDto
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
        public int? techTopicId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
