using System;
using System.Collections.Generic;

namespace Legendary.Business.Models.Video
{
    public class VideoItemDto
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
        /// Gets or sets collection Categories
        /// </summary>
        public virtual ICollection<CategoryDto> Categories { get; set; }
        /// <summary>
        /// Gets or sets AvgRating.
        /// </summary>
        public byte AvgRating { get; set; }
        /// <summary>
        /// Gets or sets Referencr on Video.
        /// </summary>
        public string ReferenceOnVideo { get; set; }
        /// <summary>
        /// Gets or sets Date Create Video.
        /// </summary>
        public DateTime DateCreate { get; set; }
    }
}