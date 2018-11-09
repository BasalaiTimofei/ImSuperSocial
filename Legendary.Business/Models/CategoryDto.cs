using System.Collections.Generic;
using Legendary.Business.Models.Video;

namespace Legendary.Business.Models
{
    public class CategoryDto
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets collection Video.
        /// </summary>
        public virtual ICollection<VideoFullModel> Video { get; set; }
    }
}