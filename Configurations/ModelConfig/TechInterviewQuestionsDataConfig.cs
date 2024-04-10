using api.techunsolved.com.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.techunsolved.com.Configurations.ModelConfig
{
    public class TechInterviewQuestionsDataConfig : IEntityTypeConfiguration<TechInterview_Questions>
    {
        public void Configure(EntityTypeBuilder<TechInterview_Questions> builder)
        {
            builder.ToTable("TechInterviewQuestions");

            builder.HasKey(x => x.QuestionId);
            builder.Property(x => x.QuestionId).UseIdentityColumn();
            builder.Property(x => x.QuestionName).IsRequired();

            builder.HasData(new List<TechInterview_Questions>()
            {
                #region C# Interview Questions
                new TechInterview_Questions(){ QuestionId = 151190, QuestionName = "What are the features of C# Language?", Level = Levels.Beginners.ToString(), TechModulesId = 3001, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 151191, QuestionName = "What is Command Language Runtime?", Level = Levels.Beginners.ToString(), TechModulesId = 3001, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 151192, QuestionName = "What is the JIT compiler process in C#?", Level = Levels.Beginners.ToString(), TechModulesId = 3001, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 151193, QuestionName = "What are the types of classes in C#?", Level = Levels.Beginners.ToString(), TechModulesId = 3001, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 151194, QuestionName = "What is Garbage Collection in C#?", Level = Levels.Beginners.ToString(), TechModulesId = 3001, CreateDate = DateTime.Now },

                #endregion
                #region ASP.Net MVC Interview Questions
                new TechInterview_Questions(){ QuestionId = 152190, QuestionName = "What is MVC (Model View Controller)?", Level = Levels.Beginners.ToString(), TechModulesId = 3003, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 152191, QuestionName = "What are the advantages of MVC?", Level = Levels.Beginners.ToString(), TechModulesId = 3003, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 152192, QuestionName = "Explain MVC application life cycle?", Level = Levels.Beginners.ToString(), TechModulesId = 3003, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 152193, QuestionName = "What are the different return types of controller action method?", Level = Levels.Beginners.ToString(), TechModulesId = 3003, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 152194, QuestionName = "What are the Filters in MVC?", Level = Levels.Beginners.ToString(), TechModulesId = 3003, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 152195, QuestionName = "What are the Action Filters in MVC?", Level = Levels.Beginners.ToString(), TechModulesId = 3003, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 152196, QuestionName = "Explain what is Routing in MVC?", Level = Levels.Beginners.ToString(), TechModulesId = 3003, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 152197, QuestionName = "What is Route in MVC?", Level = Levels.Beginners.ToString(), TechModulesId = 3003, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 152198, QuestionName = "What is the Default Route in MVC?", Level = Levels.Beginners.ToString(), TechModulesId = 3003, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 152199, QuestionName = "What is the difference between TempData, ViewData and ViewBag?", Level = Levels.Beginners.ToString(), TechModulesId = 3003, CreateDate = DateTime.Now },
                new TechInterview_Questions(){ QuestionId = 152200, QuestionName = "What is Partial View in MVC?", Level = Levels.Beginners.ToString(), TechModulesId = 3003, CreateDate = DateTime.Now },

                #endregion
            });

            builder.HasOne(x => x.techModules)
                .WithMany(x => x.techInterview_Questions)
                .HasForeignKey(x => x.TechModulesId)
                .HasConstraintName("FK_TechInterviewQuestions_TechModule");
        }
    }
}
