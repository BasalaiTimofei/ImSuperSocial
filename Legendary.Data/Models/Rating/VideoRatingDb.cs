using Legendary.Data.Models.User;
using System.Collections.Generic;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Models.Rating
{
    /// <summary>
    /// Video rating DataVase model.
    /// </summary>
    public class VideoRatingDb
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

        public override bool Equals(object obj)
        {
            var db = obj as VideoRatingDb;
            return db != null &&
                   Id == db.Id &&
                   EqualityComparer<UserDb>.Default.Equals(User, db.User) &&
                   EqualityComparer<VideoDb>.Default.Equals(Video, db.Video) &&
                   Rating == db.Rating;
        }

        public override int GetHashCode()
        {
            var hashCode = 330983822;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<UserDb>.Default.GetHashCode(User);
            hashCode = hashCode * -1521134295 + EqualityComparer<VideoDb>.Default.GetHashCode(Video);
            hashCode = hashCode * -1521134295 + Rating.GetHashCode();
            return hashCode;
        }
    }
}