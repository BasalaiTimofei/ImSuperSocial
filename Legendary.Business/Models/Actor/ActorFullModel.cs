using System.Collections.Generic;

namespace Legendary.Business.Models.Actor
{
    /// <summary>
    /// Actor DataTransferObject model.
    /// </summary>
    public class ActorFullModel
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
        /// Gets or sets reference on image with cator.
        /// </summary>
        public string ImgLink { get; set; }
        /// <summary>
        /// Gets or sets actor gender.
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Gets or sets was born Acctor.
        /// </summary>
        public Country Country { get; set; }
        /// <summary>
        /// Gets or sets actor Rating.
        /// </summary>
        public byte AvgRating { get; set; }

        public override bool Equals(object obj)
        {
            var actor = obj as ActorFullModel;
            return actor != null &&
                   Id == actor.Id &&
                   Name == actor.Name &&
                   ImgLink == actor.ImgLink &&
                   Gender == actor.Gender &&
                   EqualityComparer<Country>.Default.Equals(Country, actor.Country) &&
                   AvgRating == actor.AvgRating;
        }

        public override int GetHashCode()
        {
            var hashCode = 1544206549;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ImgLink);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Gender);
            hashCode = hashCode * -1521134295 + EqualityComparer<Country>.Default.GetHashCode(Country);
            hashCode = hashCode * -1521134295 + AvgRating.GetHashCode();
            return hashCode;
        }
    }
}
