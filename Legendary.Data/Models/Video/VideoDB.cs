using System;
using System.Collections.Generic;
using Legendary.Data.Models.Actor;
using Legendary.Data.Models.Rating;
using Legendary.Data.Models.Studio;
using Legendary.Data.Models.User;

namespace Legendary.Data.Models.Video
{
    /// <summary>
    /// Video DataBase model.
    /// </summary>
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
        public virtual ICollection<VideoRatingDb> Rating { get; set; }
        /// <summary>
        /// Gets or sets collection video Commets.
        /// </summary>
        public virtual ICollection<CommentDb> Comments { get; set; }
        /// <summary>
        /// Gets or sets collection Actors.
        /// </summary>
        public virtual ICollection<ActorDb> Actor { get; set; }
        /// <summary>
        /// Gets or sets Studio.
        /// </summary>
        public virtual StudioDb Studio { get; set; }
        /// <summary>
        /// Gets or sets User witch the added Video.
        /// </summary>
        public virtual UserDb Creator { get; set; }

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