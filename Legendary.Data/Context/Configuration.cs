using System.Data.Entity.ModelConfiguration;
using Legendary.Data.Models.Actor;
using Legendary.Data.Models.Country;
using Legendary.Data.Models.Rating;
using Legendary.Data.Models.Studio;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Context
{
    public class VideoDbConfiguration : EntityTypeConfiguration<VideoDb>
    {
        public VideoDbConfiguration()
        {
            HasKey(h => h.Id);

            HasMany(m => m.Comments)
                .WithRequired(n => n.Video);
            HasMany(m => m.Categories)
                .WithMany(c => c.Video);
            HasMany(p => p.Rating)
                .WithRequired(m => m.Video);

            Property(p => p.Name).IsRequired().HasMaxLength(100).IsUnicode();
            Property(p => p.ReferenceOnVideo).IsRequired();
            Property(p => p.DateCreate).IsRequired().HasColumnType("datetime2");
            Property(p => p.ImgLink).IsRequired();
            Property(p => p.GifLink).IsRequired();
        }
    }

    public class CategoryDbConfiguration : EntityTypeConfiguration<CategoryDb>
    {
        public CategoryDbConfiguration()
        {
            HasKey(k => k.Id);
            HasMany(m => m.Video)
                .WithMany(m => m.Categories);
            HasMany(m => m.Rating)
                .WithRequired(r => r.Category);

            Property(p => p.ImgLink).IsRequired();
            Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }

    public class CommentDbConfiguration : EntityTypeConfiguration<CommentDb>
    {
        public CommentDbConfiguration()
        {
            HasKey(k => k.Id);

            HasRequired(r => r.User)
                .WithMany(/*r => r.Comment*/);
            HasRequired(r => r.Video)
                .WithMany(m => m.Comments);

            Property(p => p.Comment).IsRequired().HasMaxLength(500).IsUnicode();
            Property(p => p.DateCreate).IsRequired().HasColumnType("datetime2");
        }
    }

    public class VideoRatingDbConfiguration : EntityTypeConfiguration<VideoRatingDb>
    {
        public VideoRatingDbConfiguration()
        {
            HasKey(k => k.Id);

            HasRequired(r => r.Video)
                .WithMany(m => m.Rating);
            HasRequired(r => r.User)
                .WithMany( /*r => r.Rating*/);

            Property(p => p.Rating).IsRequired();
        }
    }

    public class StudioRatingDbConfiguration : EntityTypeConfiguration<StudioRatingDb>
    {
        public StudioRatingDbConfiguration()
        {
            HasKey(k => k.Id);

            HasRequired(r => r.Studio)
                .WithMany(m => m.Rating);
            HasRequired(r => r.User)
                .WithMany( /*r => r.Rating*/);

            Property(p => p.Rating).IsRequired();
        }
    }

    public class ActorRatingDbConfiguration : EntityTypeConfiguration<ActorRatingDb>
    {
        public ActorRatingDbConfiguration()
        {
            HasKey(k => k.Id);

            HasRequired(r => r.Actor)
                .WithMany(m => m.Rating);
            HasRequired(r => r.User)
                .WithMany( /*r => r.Rating*/);

            Property(p => p.Rating).IsRequired();
        }
    }
    public class CategoryRatingDbConfiguration : EntityTypeConfiguration<CategoryRatingDb>
    {
        public CategoryRatingDbConfiguration()
        {
            HasKey(k => k.Id);

            HasRequired(r => r.Category)
                .WithMany(m => m.Rating);
            HasRequired(r => r.User)
                .WithMany( /*r => r.Rating*/);

            Property(p => p.Rating).IsRequired();
        }
    }

    public class ActorDbConfiguration : EntityTypeConfiguration<ActorDb>
    {
        public ActorDbConfiguration()
        {
            HasKey(k => k.Id);

            HasMany(m => m.Video)
                .WithMany(m => m.Actor);
            HasMany(m => m.Rating)
                .WithRequired(r => r.Actor);

            Property(p => p.Gender).IsRequired().HasMaxLength(20);
            Property(p => p.Name).IsRequired().HasMaxLength(100);
            Property(p => p.ImgLink).IsRequired();
        }
    }

    public class CountryDbConfiguration : EntityTypeConfiguration<CountryDb>
    {
        public CountryDbConfiguration()
        {
            HasKey(k => k.Id);

            HasMany(m => m.Actors)
                .WithOptional(o => o.Country);
            HasMany(m => m.Studio)
                .WithRequired(r => r.Cauntry);

            Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }

    public class StudioDbConfiguration : EntityTypeConfiguration<StudioDb>
    {
        public StudioDbConfiguration()
        {
            HasKey(k => k.Id);

            HasRequired(r => r.Cauntry)
                .WithMany(m => m.Studio);
            HasMany(m => m.Video)
                .WithOptional(o => o.Studio);
            HasMany(m => m.Rating)
                .WithRequired(r => r.Studio);

            Property(p => p.Name).IsRequired().HasMaxLength(50);
            Property(p => p.ImgLink).IsRequired();
        }
    }
}