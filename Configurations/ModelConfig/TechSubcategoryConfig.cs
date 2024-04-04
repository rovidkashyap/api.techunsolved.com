using api.techunsolved.com.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.techunsolved.com.Configurations.ModelConfig
{
    public class TechSubcategoryConfig : IEntityTypeConfiguration<TechSubcategory>
    {
        public void Configure(EntityTypeBuilder<TechSubcategory> builder)
        {
            builder.ToTable("TechSubCategory");
            builder.HasKey(x => x.TechSubcategoryId);

            builder.Property(x => x.TechSubcategoryId).UseIdentityColumn();

            builder.Property(x => x.TechSubcategoryName).IsRequired();
            builder.Property(x => x.TechSubcategoryName).HasMaxLength(250);
            builder.Property(x => x.Initial).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);

            builder.HasData(new List<TechSubcategory>()
            {
                // -------------------- SOFTWARE DEVELOPMENT ----------------------------- //
                new TechSubcategory(){ TechSubcategoryId = 2001, TechSubcategoryName = ".Net Development", Description = ".Net Development Description", Initial = "dotnet-development", TechCategoryId = 1001, CreateDate = DateTime.Now },
                new TechSubcategory(){ TechSubcategoryId = 2002, TechSubcategoryName = "Java Development", Description = "Java Development Description", Initial = "java-development", TechCategoryId = 1001, CreateDate = DateTime.Now },
                new TechSubcategory(){ TechSubcategoryId = 2003, TechSubcategoryName = "JavaScript Frameworks", Description = "JavaScript Frameworks Description", Initial = "javascript-frameworks", TechCategoryId = 1001, CreateDate = DateTime.Now },
                new TechSubcategory(){ TechSubcategoryId = 2004, TechSubcategoryName = "FrontEnd Development", Description = "FrontEnd Development Description", Initial = "front-end-development", TechCategoryId = 1001, CreateDate = DateTime.Now },
                // --------------------  CLOUD DEVELOPMENT  ----------------------------- //
                new TechSubcategory(){ TechSubcategoryId = 2108, TechSubcategoryName = "Microsoft Cloud", Description = "Microsoft Cloud Description", Initial = "microsoft-cloud-development", TechCategoryId = 1102, CreateDate = DateTime.Now },
                new TechSubcategory(){ TechSubcategoryId = 2109, TechSubcategoryName = "Amazon Cloud", Description = "Amazon Cloud Description", Initial = "amazon-cloud-development", TechCategoryId = 1102, CreateDate = DateTime.Now },
                new TechSubcategory(){ TechSubcategoryId = 2110, TechSubcategoryName = "Google Cloud", Description = "Google Cloud Description", Initial = "google-cloud-development", TechCategoryId = 1102, CreateDate = DateTime.Now },
                // --------------------      DATABASES     ----------------------------- //
                new TechSubcategory(){ TechSubcategoryId = 2211, TechSubcategoryName = "Microsoft Databases", Description = "Microsoft Databases Description", Initial = "microsoft-databases", TechCategoryId = 1203, CreateDate = DateTime.Now },
                new TechSubcategory(){ TechSubcategoryId = 2212, TechSubcategoryName = "Open Source Databases", Description = "Open Source Databases Description", Initial = "open-source-databases", TechCategoryId = 1203, CreateDate = DateTime.Now },
                new TechSubcategory(){ TechSubcategoryId = 2213, TechSubcategoryName = "Oracle Databases", Description = "Oracle Databases Description", Initial = "oracle-databases", TechCategoryId = 1203, CreateDate = DateTime.Now },
                // -------------------- DEVELOPMENT TOOLS  ----------------------------- //
                //new TechSubcategory(){ TechSubcategoryId = 2311, TechSubcategoryName = "Formitter/Beautifier", Description = "Formitter/Beautifier Description", Initial = "formitter-and-beautifier", TechCategoryId = 1304, CreateDate = DateTime.Now },
                //new TechSubcategory(){ TechSubcategoryId = 2312, TechSubcategoryName = "Code Minifier", Description = "Code Minifier Description", Initial = "code-minifier", TechCategoryId = 1304, CreateDate = DateTime.Now },
                //new TechSubcategory(){ TechSubcategoryId = 2313, TechSubcategoryName = "Converters", Description = "Converters Description", Initial = "converters", TechCategoryId = 1304, CreateDate = DateTime.Now }
            });

            builder.HasOne(n => n.TechCategory)
                .WithMany(n => n.TechSubCategories)
                .HasForeignKey(n => n.TechCategoryId)
                .HasConstraintName("FK_TechSubCategory_TechCategory");
        }
    }
}
