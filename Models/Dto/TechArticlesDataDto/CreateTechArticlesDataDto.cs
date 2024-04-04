namespace api.techunsolved.com.Models.Dto.TechArticlesDataDto
{
    public class CreateTechArticlesDataDto
    {
        public int TechArticlesDataId { get; set; }
        public string? program_heading { get; set; }
        public string? program_code { get; set; }
        public string? output_heading { get; set; }
        public string? output_code { get; set; }
        public string? other_heading { get; set; }
        public string? other_code { get; set; }
        public int? TechArticlesId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
