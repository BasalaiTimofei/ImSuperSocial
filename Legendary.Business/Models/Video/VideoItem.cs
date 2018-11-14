using System;
using System.Collections.Generic;

namespace Legendary.Business.Models.Video
{
    /// <summary>
    /// Video model individual view.
    /// </summary>
    public class VideoItem
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets collection Categories
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; }
        /// <summary>
        /// Gets or sets Actors.
        /// </summary>
        public virtual ICollection<Actor> Actors { get; set; }
        /// <summary>
        /// Gets or sets Studio.
        /// </summary>
        public virtual Studio Studio { get; set; }
        /// <summary>
        /// Gets or sets AvgRating.
        /// </summary>
        public byte AvgRating { get; set; }
        /// <summary>
        /// Gets or sets Referencr on Video.
        /// </summary>
        public string ReferenceOnVideo { get; set; }
        /// <summary>
        /// Gets or sets Date Create Video.
        /// </summary>
        public DateTime? DateCreate { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as VideoItem;
            return item != null &&
                   Id == item.Id &&
                   Name == item.Name &&
                   EqualityComparer<ICollection<Category>>.Default.Equals(Categories, item.Categories) &&
                   EqualityComparer<ICollection<Actor>>.Default.Equals(Actors, item.Actors) &&
                   EqualityComparer<Studio>.Default.Equals(Studio, item.Studio) &&
                   AvgRating == item.AvgRating &&
                   ReferenceOnVideo == item.ReferenceOnVideo &&
                   EqualityComparer<DateTime?>.Default.Equals(DateCreate, item.DateCreate);
        }

        public override int GetHashCode()
        {
            var hashCode = -218992038;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Category>>.Default.GetHashCode(Categories);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Actor>>.Default.GetHashCode(Actors);
            hashCode = hashCode * -1521134295 + EqualityComparer<Studio>.Default.GetHashCode(Studio);
            hashCode = hashCode * -1521134295 + AvgRating.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ReferenceOnVideo);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime?>.Default.GetHashCode(DateCreate);
            return hashCode;
        }
    }
}