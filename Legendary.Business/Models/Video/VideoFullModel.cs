using System;
using System.Collections.Generic;

namespace Legendary.Business.Models.Video
{
    public class VideoFullModel
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
        /// Gets or sets collection Categories.
        /// </summary>
        public virtual ICollection<CategoryDto> Categories { get; set; }
        /// <summary>
        /// Get or sets AvgRating.
        /// </summary>
        public byte AvgRating { get; set; }

        /// <summary>
        /// Gets or sets Reference On Video.
        /// </summary>
        public string ReferenceOnVideo { get; set; }
        /// <summary>
        /// Gets or sets Data Create Video.
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Gets or sets Reference on Image for Video.
        /// </summary>
        public string ImgLink { get; set; }
        /// <summary>
        /// Gets or sets Reference on Gif for Video.
        /// </summary>
        public string GifLink { get; set; }
    }
}