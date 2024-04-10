using api.techunsolved.com.Data;
using Microsoft.AspNetCore.Identity;

namespace api.techunsolved.com.Models.Dto.TechInterviewQuestionsDto
{
    public class CreateInterviewQuestionsDto
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public string Level { get; set; }

        public int TechModulesId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
