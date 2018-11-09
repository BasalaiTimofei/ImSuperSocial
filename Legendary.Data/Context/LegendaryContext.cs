using Legendary.Data.Models.User;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Context
{
    using System.Data.Entity;

    public class LegendaryContext : DbContext
    {
        public LegendaryContext()
            : base("LegendaryContext")
        {
            Database.SetInitializer<LegendaryContext>(new CreateDatabaseIfNotExists<LegendaryContext>());
        }

        public DbSet<CategoryDb> Categories { get; set; }
        public DbSet<CommentDb> Comments { get; set; }
        public DbSet<VideoDb> Video { get; set; }
        public DbSet<UserDb> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VideoDbConfiguration());
            modelBuilder.Configurations.Add(new CategoryDbConfiguration());
            modelBuilder.Configurations.Add(new CommentDbConfiguration());
            modelBuilder.Configurations.Add(new RatingDbConfiguration());

            
        }
    }
}