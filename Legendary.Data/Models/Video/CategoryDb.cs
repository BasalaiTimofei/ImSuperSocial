using System.Collections.Generic;

namespace Legendary.Data.Models.Video
{
    public class CategoryDb
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<VideoDb> Video { get; set; }
    }
}