using Legendary.Data.Models.Actor;
using Legendary.Data.Models.User;

namespace Legendary.Data.Models.Rating
{
    /// <summary>
    /// Actor rating DataBase model.
    /// </summary>
    public class ActorRatingDb
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
        /// Gets or sets Actor.
        /// </summary>
        public virtual ActorDb Actor { get; set; }
    }
}