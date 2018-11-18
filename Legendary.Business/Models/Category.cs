using System.Collections.Generic;

namespace Legendary.Business.Models
{
    /// <summary>
    /// Category DataTransferObject molel.
    /// </summary>
    public class Category
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
        /// Gets or sets reference on Image Category.
        /// </summary>
        public string ImgLink { get; set; }
        /// <summary>
        /// Gets or sets AvgRating.
        /// </summary>
        public byte Rating { get; set; }

        public override bool Equals(object obj)
        {
            var category = obj as Category;
            return category != null &&
                   Id == category.Id &&
                   Name == category.Name &&
                   ImgLink == category.ImgLink &&
                   Rating == category.Rating;
        }

        public override int GetHashCode()
        {
            var hashCode = -2054340054;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ImgLink);
            hashCode = hashCode * -1521134295 + Rating.GetHashCode();
            return hashCode;
        }
    }
}