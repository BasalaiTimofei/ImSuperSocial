using Legendary.Data.Models.User;

namespace Legendary.Data.Models.Video
{
    public class RatingDb
    {
        /// <summary>
        /// Gets or sets Id Rating.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets User.
        /// </summary>
        public virtual UserDb User { get; set; }
        /// <summary>
        /// Gets or sets Video.
        /// </summary>
        public virtual VideoDb Video { get; set; }
        /// <summary>
        /// Gets or sets Rating (1, -1).
        /// </summary>
        public sbyte Rating { get; set; }
    }
}