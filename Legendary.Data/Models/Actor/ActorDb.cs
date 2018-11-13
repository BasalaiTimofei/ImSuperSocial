using System.Collections.Generic;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Models.Actor
{
    public class ActorDb
    {
        /// <summary>
        /// Gets or sets actor Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets actor Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets reserence on Image with actor.
        /// </summary>
        public string ImgLink { get; set; }
        /// <summary>
        /// Gets or sets Gender actor.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Gets or sets video with actor.
        /// </summary>
        public virtual ICollection<VideoDb> Video { get; set; }

        public override bool Equals(object obj)
        {
            var db = obj as ActorDb;
            return db != null &&
                   Id == db.Id &&
                   Name == db.Name &&
                   ImgLink == db.ImgLink &&
                   Gender == db.Gender &&
                   EqualityComparer<ICollection<VideoDb>>.Default.Equals(Video, db.Video);
        }

        public override int GetHashCode()
        {
            var hashCode = -540937354;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ImgLink);
            hashCode = hashCode * -1521134295 + Gender.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<VideoDb>>.Default.GetHashCode(Video);
            return hashCode;
        }
    }
}