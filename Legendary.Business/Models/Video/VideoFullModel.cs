using System;
using System.Collections.Generic;
using Legendary.Business.Models.Actor;
using Legendary.Business.Models.Studio;
using Legendary.Business.Models.User;

namespace Legendary.Business.Models.Video
{
    /// <summary>
    /// Video DataTransferObject model.
    /// </summary>
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
        public virtual ICollection<Category> Categories { get; set; }
        /// <summary>
        /// Gets or sets collection Actors.
        /// </summary>
        public virtual ICollection<ActorSmallModel> Actors { get; set; }
        /// <summary>
        /// Gets or sets Studio.
        /// </summary>
        public StudioSmallModel Studio { get; set; }
        /// <summary>
        /// Gets or sets User witch the added Video.
        /// </summary>
        public virtual UserSmallModel Creator { get; set; }
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
        public DateTime? DateCreate { get; set; }

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