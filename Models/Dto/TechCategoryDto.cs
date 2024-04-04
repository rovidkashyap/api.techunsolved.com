namespace api.techunsolved.com.Models.Dto
{
    public class TechCategoryDto
    {
        public int TechCategoryId { get; set; }
        public string TechCategoryName { get; set; }
        public string Description { get; set; }
        public string Initial { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
