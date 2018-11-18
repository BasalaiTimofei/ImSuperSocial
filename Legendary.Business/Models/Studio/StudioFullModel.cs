using System.Collections.Generic;

namespace Legendary.Business.Models.Studio
{
    /// <summary>
    /// Studio DataTransferObject model.
    /// </summary>
    public class StudioFullModel
    {
        /// <summary>
        /// Gets or sets studio Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets studio Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets studio icon.
        /// </summary>
        public string ImgLink { get; set; }
        /// <summary>
        /// Gets or sets studio country.
        /// </summary>
        public virtual Country Country { get; set; }
        /// <summary>
        /// Gets or sets studio Rating.
        /// </summary>
        public byte AvgRating { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as StudioFullModel;
            return model != null &&
                   Id == model.Id &&
                   Name == model.Name &&
                   ImgLink == model.ImgLink &&
                   EqualityComparer<Country>.Default.Equals(Country, model.Country) &&
                   AvgRating == model.AvgRating;
        }

        public override int GetHashCode()
        {
            var hashCode = -1622294107;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ImgLink);
            hashCode = hashCode * -1521134295 + EqualityComparer<Country>.Default.GetHashCode(Country);
            hashCode = hashCode * -1521134295 + AvgRating.GetHashCode();
            return hashCode;
        }
    }
}
