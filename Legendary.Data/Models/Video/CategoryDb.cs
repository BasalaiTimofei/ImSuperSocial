using System.Collections.Generic;

namespace Legendary.Data.Models.Video
{
    public class CategoryDb
    {
        /// <summary>
        /// Gets or sets id categories;
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Name categories;
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets collection Video;
        /// </summary>
        public virtual ICollection<VideoDb> Video { get; set; }
    }
}