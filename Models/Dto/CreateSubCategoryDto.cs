namespace api.techunsolved.com.Models.Dto
{
    public class CreateSubCategoryDto
    {
        public int TechSubcategoryId { get; set; }
        public string TechSubcategoryName { get; set; }
        public string Description { get; set; }
        public string Initial { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
