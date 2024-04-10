using api.techunsolved.com.Configurations.ModelConfig;
using api.techunsolved.com.Data;
using api.techunsolved.com.Data.Common;
using api.techunsolved.com.Services;
using Microsoft.EntityFrameworkCore;

namespace api.techunsolved.com.TechContext
{
    public class DataContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        public DataContext(DbContextOptions<DataContext> options, IDateTimeService dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<TechCategory> techCategories { get; set; }
        public DbSet<TechSubcategory> techSubCategories { get; set; }
        public DbSet<TechModules> techModules { get; set; }

        public DbSet<TechTopics> techTopics { get; set; }
        public DbSet<TechArticles> techArticles { get; set; }

        public DbSet<TechArticlesData> techArticlesData { get; set; }

        public DbSet<TechInterview_Questions> techInterviewQuestions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TechCategoryConfig());
            modelBuilder.ApplyConfiguration(new TechSubcategoryConfig());
            modelBuilder.ApplyConfiguration(new TechModulesConfig());

            modelBuilder.ApplyConfiguration(new TechTopicConfig());
            modelBuilder.ApplyConfiguration(new TechArticleConfig());

            modelBuilder.ApplyConfiguration(new TechArticlesDataConfig());
            modelBuilder.ApplyConfiguration(new TechInterviewQuestionsDataConfig());

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = _dateTime.ISTNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = _dateTime.ISTNow;
                        break;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}