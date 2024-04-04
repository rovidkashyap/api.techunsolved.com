namespace api.techunsolved.com.Models.Dto.TechTopicDto
{
    public class CreateTechTopicDto
    {
        public int TechTopicId { get; set; }
        public string TechTopicName { get; set; }
        public string Level { get; set; }

        public int? TechModulesId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
