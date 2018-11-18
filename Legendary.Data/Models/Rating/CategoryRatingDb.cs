using Legendary.Data.Models.User;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Models.Rating
{
    /// <summary>
    /// Rating Category model.
    /// </summary>
    public class CategoryRatingDb
    {        
        /// <summary>
        /// Gets or sets rating Id.
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
        /// Gets or sets Category.
        /// </summary>
        public virtual CategoryDb Category { get; set; }
    }
}
