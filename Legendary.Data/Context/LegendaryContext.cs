using Legendary.Data.Models.Actor;
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

        public virtual DbSet<CategoryDb> Categories { get; set; }
        public virtual DbSet<CommentDb> Comments { get; set; }
        public virtual DbSet<VideoDb> Video { get; set; }
        public virtual DbSet<UserDb> Users { get; set; }
        public virtual DbSet<ActorDb> Actors { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VideoDbConfiguration());
            modelBuilder.Configurations.Add(new CategoryDbConfiguration());
            modelBuilder.Configurations.Add(new CommentDbConfiguration());
            modelBuilder.Configurations.Add(new RatingDbConfiguration());
            modelBuilder.Configurations.Add(new ActorDbConfiguration());


        }
    }
}