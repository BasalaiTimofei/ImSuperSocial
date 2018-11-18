using System.Collections.Generic;
using Legendary.Data.Models.Rating;

namespace Legendary.Data.Models.Video
{
    /// <summary>
    /// Category DataBase model.
    /// </summary>
    public class CategoryDb
    {
        /// <summary>
        /// Gets or sets id categories.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Name categories.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Reference on Image Category.
        /// </summary>
        public string ImgLink { get; set; }
        /// <summary>
        /// Gets or sets collection rating.
        /// </summary>
        public virtual ICollection<CategoryRatingDb> Rating { get; set; }
        /// <summary>
        /// Gets or sets collection Video.
        /// </summary>
        public virtual ICollection<VideoDb> Video { get; set; }

        public override bool Equals(object obj)
        {
            var db = obj as CategoryDb;
            return db != null &&
                   Id == db.Id &&
                   Name == db.Name &&
                   ImgLink == db.ImgLink &&
                   EqualityComparer<ICollection<VideoDb>>.Default.Equals(Video, db.Video);
        }

        public override int GetHashCode()
        {
            var hashCode = -1470595130;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ImgLink);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<VideoDb>>.Default.GetHashCode(Video);
            return hashCode;
        }
    }
}