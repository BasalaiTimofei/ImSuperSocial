using System;
using System.Collections.Generic;

namespace Legendary.Data.Models.Video
{
    public class VideoDb
    {
        /// <summary>
        /// Gets or sets a video Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets a video Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets collection video Categories.
        /// </summary>
        public virtual ICollection<CategoryDb> Categories { get; set; }
        /// <summary>
        /// Gets or sets collection video Rating.
        /// </summary>
        public virtual ICollection<RatingDb> Rating { get; set; }
        /// <summary>
        /// Gets or sets collection video Commets.
        /// </summary>
        public virtual ICollection<CommentDb> Comments { get; set; }

        /// <summary>
        /// Gets or sets reference on Video.
        /// </summary>
        public string ReferenceOnVideo { get; set; }
        /// <summary>
        /// Gets or sets Date added video
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Gets or sets reference image for video
        /// </summary>
        public string ImgLink { get; set; }
        /// <summary>
        /// Gets or sets reference gif for video
        /// </summary>
        public string GifLink { get; set; }
    }
}