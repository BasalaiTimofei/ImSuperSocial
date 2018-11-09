using System.Data.Entity.ModelConfiguration;
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

    public class RatingDbConfiguration : EntityTypeConfiguration<RatingDb>
    {
        public RatingDbConfiguration()
        {
            HasKey(k => k.Id);

            HasRequired(r => r.Video)
                .WithMany(m => m.Rating);
            HasRequired(r => r.User)
                .WithMany( /*r => r.Rating*/);

            Property(p => p.Rating).IsOptional();
        }
    }

}