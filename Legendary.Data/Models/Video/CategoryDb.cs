using System.Collections.Generic;

namespace Legendary.Data.Models.Video
{
    public class CategoryDb
    {
        /// <summary>
        /// Gets or sets id categories;
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Name categories;
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets collection Video;
        /// </summary>
        public virtual ICollection<VideoDb> Video { get; set; }

        public override bool Equals(object obj)
        {
            var db = obj as CategoryDb;
            return db != null &&
                   Id == db.Id &&
                   Name == db.Name &&
                   EqualityComparer<ICollection<VideoDb>>.Default.Equals(Video, db.Video);
        }

        public override int GetHashCode()
        {
            var hashCode = 1637481218;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<VideoDb>>.Default.GetHashCode(Video);
            return hashCode;
        }
    }
}