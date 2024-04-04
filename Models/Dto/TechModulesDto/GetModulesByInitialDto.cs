namespace api.techunsolved.com.Models.Dto.TechModulesDto
{
    public class GetModulesByInitialDto
    {
        public int TechModulesId { get; set; }
        public string TechModulesName { get; set; }
        public string Description { get; set; }
        public string Initial { get; set; }
        public int TechSubCategoryId { get; set; }
        public string TechSubCategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
