using System.Data.Entity.ModelConfiguration;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Models
{
    public class VideoDbConfiguration : EntityTypeConfiguration<VideoDb>
    {
        public VideoDbConfiguration()
        {
            HasKey(h => h.Id);
            HasRequired(r => r.Information)
                .WithRequiredPrincipal(p => p.Video);
            HasRequired(r => r.Img)
                .WithRequiredPrincipal(p => p.Video);
            HasMany(m => m.Categories)
                .WithMany(c => c)
            Property(p => p.Name).IsRequired().HasMaxLength(100).IsUnicode();
            Property(p => p.Rating).IsRequired();
        }
    }

    public class VideoImgDbConfiguration : EntityTypeConfiguration<VideoImgDb>
    {
        public VideoImgDbConfiguration()
        {
            HasKey(k => k.Id);
            HasRequired(r => r.Video)
                .WithRequiredPrincipal(r => r.Img);
            Property(p => p.ImgLink).HasMaxLength(300).IsRequired();
            Property(p => p.GifLink).HasMaxLength(300).IsRequired();
        }
    }

    public class VideoInformationDbConfiguration : EntityTypeConfiguration<VideoInformationDb>
    {
        public VideoInformationDbConfiguration()
        {
            HasKey(k => k.Id);
            HasRequired(r => r.Video)
                .WithRequiredPrincipal(r => r.Information);
            HasMany(m => m.Comments)
                .WithMany(n => n.);
        }
    }

    public class CategoryDbConfiguration : EntityTypeConfiguration<CategoryDb>
    {
        public CategoryDbConfiguration()
        {
            
        }
    }

    public class CommentDbConfiguration : EntityTypeConfiguration<CommentDb>
    {
        public CommentDbConfiguration()
        {
            
        }
    }

}