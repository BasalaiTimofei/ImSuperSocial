using System;
using System.Collections.Generic;
using Legendary.Business.Models.Actor;
using Legendary.Business.Models.Studio;

namespace Legendary.Business.Models.Video
{
    /// <summary>
    /// Video DataTransferObject model.
    /// </summary>
    public class VideoFullModel
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
        /// Gets or sets collection Categories.
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; }
        /// <summary>
        /// Gets or sets collection Actors.
        /// </summary>
        public virtual ICollection<ActorSmallModel> Actors { get; set; }
        /// <summary>
        /// Gets or sets Studio.
        /// </summary>
        public StudioSmallModel Studio { get; set; }
        /// <summary>
        /// Get or sets AvgRating.
        /// </summary>
        public byte AvgRating { get; set; }

        /// <summary>
        /// Gets or sets Reference On Video.
        /// </summary>
        public string ReferenceOnVideo { get; set; }
        /// <summary>
        /// Gets or sets Data Create Video.
        /// </summary>
        public DateTime? DateCreate { get; set; }

        /// <summary>
        /// Gets or sets Reference on Image for Video.
        /// </summary>
        public string ImgLink { get; set; }
        /// <summary>
        /// Gets or sets Reference on Gif for Video.
        /// </summary>
        public string GifLink { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as VideoFullModel;
            return model != null &&
                   Id == model.Id &&
                   Name == model.Name &&
                   EqualityComparer<ICollection<Category>>.Default.Equals(Categories, model.Categories) &&
                   EqualityComparer<ICollection<ActorSmallModel>>.Default.Equals(Actors, model.Actors) &&
                   EqualityComparer<StudioSmallModel>.Default.Equals(Studio, model.Studio) &&
                   AvgRating == model.AvgRating &&
                   ReferenceOnVideo == model.ReferenceOnVideo &&
                   EqualityComparer<DateTime?>.Default.Equals(DateCreate, model.DateCreate) &&
                   ImgLink == model.ImgLink &&
                   GifLink == model.GifLink;
        }

        public override int GetHashCode()
        {
            var hashCode = -1008877277;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Category>>.Default.GetHashCode(Categories);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<ActorSmallModel>>.Default.GetHashCode(Actors);
            hashCode = hashCode * -1521134295 + EqualityComparer<StudioSmallModel>.Default.GetHashCode(Studio);
            hashCode = hashCode * -1521134295 + AvgRating.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ReferenceOnVideo);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime?>.Default.GetHashCode(DateCreate);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ImgLink);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GifLink);
            return hashCode;
        }
    }
}