using System.Collections.Generic;

namespace Legendary.Business.Models
{
    /// <summary>
    /// Studio DataTransferObject model.
    /// </summary>
    public class Studio
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
        /// Gets or sets studio icon.
        /// </summary>
        public string ImgLink { get; set; }
        /// <summary>
        /// Gets or sets studio country.
        /// </summary>
        public virtual Country Country { get; set; }
        /// <summary>
        /// Gets or sets studio Rating.
        /// </summary>
        public byte AvgRating { get; set; }
    }
}
