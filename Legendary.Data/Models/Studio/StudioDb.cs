using System.Collections.Generic;
using Legendary.Data.Models.Country;
using Legendary.Data.Models.Rating;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Models.Studio
{
    /// <summary>
    /// Studio DataBase model.
    /// </summary>
    public class StudioDb
    {
        /// <summary>
        /// Gets or sets studio Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets studio Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets reference on Icon Studio.
        /// </summary>
        public string ImgLink { get; set; }

        /// <summary>
        /// Gets or sets studio Country.
        /// </summary>
        public virtual CountryDb Cauntry { get; set; }
        /// <summary>
        /// Gets or sets collection studio Video.
        /// </summary>
        public virtual ICollection<VideoDb> Video { get; set; }
        /// <summary>
        /// Gets or sets collection studio Rating.
        /// </summary>
        public virtual ICollection<StudioRatingDb> Rating { get; set; }
    }
}