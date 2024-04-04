using api.techunsolved.com.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.techunsolved.com.Configurations.ModelConfig
{
    public class TechModulesConfig : IEntityTypeConfiguration<TechModules>
    {
        public void Configure(EntityTypeBuilder<TechModules> builder)
        {
            builder.ToTable("TechModules");
            builder.HasKey(x => x.TechModulesId);

            builder.Property(x => x.TechModulesId).UseIdentityColumn();

            builder.Property(x => x.TechModulesName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Initial).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);

            builder.HasData(new List<TechModules>()
            { 
                // -------------------- .NET DEVELOPMENT ----------------------------- //
                new TechModules(){ TechModulesId = 3001, TechModulesName = "C#", Description = "C# Description", Initial = "c-sharp", TechSubcategoryId = 2001, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3002, TechModulesName = ".Net Core", Description = ".Net Core Description", Initial = "dotnet-core", TechSubcategoryId = 2001, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3003, TechModulesName = "ASP.Net MVC", Description = "ASP.Net MVC Description", Initial = "mvc", TechSubcategoryId = 2001, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3004, TechModulesName = "ASP.Net Web API", Description = "ASP.Net Web API Description", Initial = "web-api", TechSubcategoryId = 2001, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3005, TechModulesName = "ASP.Net MVC Core", Description = "ASP.Net MVC Core Description", Initial = "mvc-core", TechSubcategoryId = 2001, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3006, TechModulesName = "Entity Framework", Description = "Entity Framework Description", Initial = "entity-framework", TechSubcategoryId = 2001, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3007, TechModulesName = "Entity Framework Core", Description = "Entity Framework Core Description", Initial = "entity-framework-core", TechSubcategoryId = 2001, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3008, TechModulesName = "LINQ", Description = "LINQ Description", Initial = "linq", TechSubcategoryId = 2001, CreateDate = DateTime.Now },
                // -------------------- JAVA DEVELOPMENT ----------------------------- //
                new TechModules(){ TechModulesId = 3101, TechModulesName = "Java", Description = "Java Description", Initial = "java", TechSubcategoryId = 2002, CreateDate = DateTime.Now },
                // -------------------- JS AND FRAMEWORKS ----------------------------- //
                new TechModules(){ TechModulesId = 3201, TechModulesName = "JavaScript", Description = "JavaScript Description", Initial = "javascript", TechSubcategoryId = 2003, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3202, TechModulesName = "ReactJS", Description = "ReactJS Description", Initial = "reactjs", TechSubcategoryId = 2003, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3203, TechModulesName = "AngularJS", Description = "AngularJS Description", Initial = "angularjs", TechSubcategoryId = 2003, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3204, TechModulesName = "VueJS", Description = "VueJS Description", Initial = "vuejs", TechSubcategoryId = 2003, CreateDate = DateTime.Now },
                // -------------------- FRONT END DEVELOPMENT ----------------------------- //
                new TechModules(){ TechModulesId = 3301, TechModulesName = "CSS", Description = "CSS Description", Initial = "css", TechSubcategoryId = 2004, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3302, TechModulesName = "jQuery", Description = "JQuery Description", Initial = "jquery", TechSubcategoryId = 2004, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3303, TechModulesName = "Bootstrap", Description = "Bootstrap Description", Initial = "bootstrap", TechSubcategoryId = 2004, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3304, TechModulesName = "Tailwind CSS", Description = "Tailwind CSS Description", Initial = "tailwind-css", TechSubcategoryId = 2004, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3305, TechModulesName = "HTML5", Description = "HTML5 Description", Initial = "html", TechSubcategoryId = 2004, CreateDate = DateTime.Now },

                // -------------------- MICROSOFT CLOUD ----------------------------- //
                new TechModules(){ TechModulesId = 3501, TechModulesName = "Microsoft Azure", Description = "MS Azure Description", Initial = "microsoft-azure", TechSubcategoryId = 2108, CreateDate = DateTime.Now },
                // -------------------- AMAZON CLOUD ----------------------------- //
                new TechModules(){ TechModulesId = 3601, TechModulesName = "AWS (Amazon Web Services)", Description = "AWS Description", Initial = "amazon-web-services", TechSubcategoryId = 2109, CreateDate = DateTime.Now },
                // -------------------- CLOUD COMPUTING ----------------------------- //
                new TechModules(){ TechModulesId = 3701, TechModulesName = "Cloud Computing", Description = "Cloud Computing Description", Initial = "cloud-computing", TechSubcategoryId = 2110, CreateDate = DateTime.Now },

                // -------------------- MICROSOFT DATABASES ----------------------------- //
                new TechModules(){ TechModulesId = 3801, TechModulesName = "SQL Server", Description = "SQL Server Description", Initial = "sql-server", TechSubcategoryId = 2211, CreateDate = DateTime.Now },
                // -------------------- OPEN SOURCE DATABASES ----------------------------- //
                new TechModules(){ TechModulesId = 3901, TechModulesName = "MySQL", Description = "MySQL Description", Initial = "mysql", TechSubcategoryId = 2212, CreateDate = DateTime.Now },
                new TechModules(){ TechModulesId = 3902, TechModulesName = "PostgreSQL", Description = "PostgreSQL Description", Initial = "postgre-sql", TechSubcategoryId = 2212, CreateDate = DateTime.Now },
                // -------------------- ORACLE DATABASES ----------------------------- //
                new TechModules(){ TechModulesId = 4001, TechModulesName = "Oracle", Description = "Oracle Description", Initial = "oracle", TechSubcategoryId = 2213, CreateDate = DateTime.Now },
            });

            builder.HasOne(x => x.TechSubCategories)
                .WithMany(x => x.techModules)
                .HasForeignKey(x => x.TechSubcategoryId)
                .HasConstraintName("FK_TechModules_TechSubCategory");
        }
    }
}
