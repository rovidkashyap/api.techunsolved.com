namespace api.techunsolved.com.Models.Dto
{
    public class GetSubCategoryByCategoryNameDto
    {
        public int TechSubcategoryId { get; set; }
        public string TechSubcategoryName { get; set; }
        public string Description { get; set; }
        public string Initial { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
