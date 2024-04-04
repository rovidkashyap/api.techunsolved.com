namespace api.techunsolved.com.Models.Dto
{
    public class UpdateSubCategoryDto
    {
        public int TechSubcategoryId { get; set; }
        public string TechSubcategoryName { get; set; }
        public string Description { get; set; }
        public string Initial { get; set; }
        public int categoryId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
