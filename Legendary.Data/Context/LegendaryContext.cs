using Legendary.Data.Models.User;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LegendaryContext : DbContext
    {
        public LegendaryContext()
            : base("name=LegendaryContext")
        {
        }

        public DbSet<CategoryDb> Categories { get; set; }
        public DbSet<CommentDb> Comments { get; set; }
        public DbSet<VideoDb> Video { get; set; }
        public DbSet<UserDb> Users { get; set; }
    }
}