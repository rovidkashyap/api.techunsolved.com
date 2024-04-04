using api.techunsolved.com.Data;

namespace api.techunsolved.com.Models.Dto
{
    public class GetSubCategoryByCatIdDto
    {
        public int TechSubcategoryId { get; set; }
        public string TechSubcategoryName { get; set; }
        public string Description { get; set; }
        public string Initial { get; set; }

        public int? TechCategoryId { get; set; }
        public string TechCategoryName { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
