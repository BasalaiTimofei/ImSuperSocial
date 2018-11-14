using System.Collections.Generic;
using Legendary.Data.Models.Country;
using Legendary.Data.Models.Rating;
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
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets video with actor.
        /// </summary>
        public virtual ICollection<VideoDb> Video { get; set; }
        /// <summary>
        /// Gets or sets collection actor Rating.
        /// </summary>
        public virtual ICollection<ActorRatingDb> Rating { get; set; }
        /// <summary>
        /// Geets or sets was born Actor.
        /// </summary>
        public virtual CountryDb Country { get; set; }

        public override bool Equals(object obj)
        {
            var db = obj as ActorDb;
            return db != null &&
                   Id == db.Id &&
                   Name == db.Name &&
                   ImgLink == db.ImgLink &&
                   Gender == db.Gender &&
                   EqualityComparer<ICollection<VideoDb>>.Default.Equals(Video, db.Video) &&
                   EqualityComparer<ICollection<ActorRatingDb>>.Default.Equals(Rating, db.Rating) &&
                   EqualityComparer<CountryDb>.Default.Equals(Country, db.Country);
        }

        public override int GetHashCode()
        {
            var hashCode = -564477897;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ImgLink);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Gender);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<VideoDb>>.Default.GetHashCode(Video);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<ActorRatingDb>>.Default.GetHashCode(Rating);
            hashCode = hashCode * -1521134295 + EqualityComparer<CountryDb>.Default.GetHashCode(Country);
            return hashCode;
        }
    }
}