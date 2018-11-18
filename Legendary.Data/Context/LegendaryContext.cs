using Legendary.Data.Models.Actor;
using Legendary.Data.Models.Country;
using Legendary.Data.Models.Rating;
using Legendary.Data.Models.Studio;
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

        public virtual DbSet<CommentDb> Comments { get; set; }
        public virtual DbSet<CountryDb> Country { get; set; }

        public virtual DbSet<CategoryDb> Categories { get; set; }
        public virtual DbSet<CategoryRatingDb> CategoryRatings { get; set; }

        public virtual DbSet<VideoDb> Video { get; set; }
        public virtual DbSet<VideoRatingDb> VideoRating { get; set; }

        public virtual DbSet<UserDb> Users { get; set; }

        public virtual DbSet<ActorDb> Actors { get; set; }
        public virtual DbSet<ActorRatingDb> ActorRating { get; set; }

        public virtual DbSet<StudioDb> Studio { get; set; }
        public virtual DbSet<StudioRatingDb> StudioRating { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CommentDbConfiguration());
            modelBuilder.Configurations.Add(new CountryDbConfiguration());

            modelBuilder.Configurations.Add(new CategoryDbConfiguration());
            modelBuilder.Configurations.Add(new CategoryRatingDbConfiguration());

            modelBuilder.Configurations.Add(new VideoDbConfiguration());
            modelBuilder.Configurations.Add(new VideoRatingDbConfiguration());

            modelBuilder.Configurations.Add(new ActorDbConfiguration());
            modelBuilder.Configurations.Add(new ActorRatingDbConfiguration());

            modelBuilder.Configurations.Add(new StudioDbConfiguration());
            modelBuilder.Configurations.Add(new StudioRatingDbConfiguration());


        }
    }
}