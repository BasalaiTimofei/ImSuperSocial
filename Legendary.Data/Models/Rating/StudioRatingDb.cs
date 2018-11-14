using Legendary.Data.Models.Studio;
using Legendary.Data.Models.User;

namespace Legendary.Data.Models.Rating
{
    /// <summary>
    /// Studio rating DataBase model.
    /// </summary>
    public class StudioRatingDb
    {
        /// <summary>
        /// Gets or sets StudioRating Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Rating (1, -1).
        /// </summary>
        public sbyte Rating { get; set; }

        /// <summary>
        /// Gets or sets User.
        /// </summary>
        public virtual UserDb User { get; set; }
        /// <summary>
        /// Gets or sets Studio.
        /// </summary>
        public virtual StudioDb Studio { get; set; }
    }
}