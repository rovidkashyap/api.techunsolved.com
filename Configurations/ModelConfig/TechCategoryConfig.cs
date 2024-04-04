using api.techunsolved.com.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.techunsolved.com.Configurations.ModelConfig
{
    public class TechCategoryConfig : IEntityTypeConfiguration<TechCategory>
    {
        public void Configure(EntityTypeBuilder<TechCategory> builder)
        {
            builder.ToTable("TechCategory");
            builder.HasKey(x => x.TechCategoryId);

            builder.Property(x => x.TechCategoryId).UseIdentityColumn();

            builder.Property(x => x.TechCategoryName).IsRequired();
            builder.Property(x => x.TechCategoryName).HasMaxLength(250);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Initial).IsRequired();

            builder.HasData(new List<TechCategory>()
            {
                new TechCategory(){ TechCategoryId = 1001, TechCategoryName = "Software Development", Description = "Software Development Description", Initial = "software-development", CreateDate = DateTime.Now },
                new TechCategory(){ TechCategoryId = 1102, TechCategoryName = "Cloud Development", Description = "Cloud Development Description", Initial = "cloud-development", CreateDate = DateTime.Now },
                new TechCategory(){ TechCategoryId = 1203, TechCategoryName = "Databases", Description = "Databases Description", Initial = "databases", CreateDate = DateTime.Now },
                new TechCategory(){ TechCategoryId = 1304, TechCategoryName = "Development Tools", Description = "Development Tools Description", Initial = "development-tools", CreateDate = DateTime.Now }
            });
        }
    }
}
