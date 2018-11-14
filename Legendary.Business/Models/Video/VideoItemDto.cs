using System;
using System.Collections.Generic;

namespace Legendary.Business.Models.Video
{
    public class VideoItemDto
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
        public virtual ICollection<CategoryDto> Categories { get; set; }
        /// <summary>
        /// Gets or sets Actors.
        /// </summary>
        public virtual ICollection<ActorDto> Actors { get; set; }
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
            var dto = obj as VideoItemDto;
            return dto != null &&
                   Id == dto.Id &&
                   Name == dto.Name &&
                   EqualityComparer<ICollection<CategoryDto>>.Default.Equals(Categories, dto.Categories) &&
                   AvgRating == dto.AvgRating &&
                   ReferenceOnVideo == dto.ReferenceOnVideo &&
                   EqualityComparer<DateTime?>.Default.Equals(DateCreate, dto.DateCreate);
        }

        public override int GetHashCode()
        {
            var hashCode = -1966607756;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<CategoryDto>>.Default.GetHashCode(Categories);
            hashCode = hashCode * -1521134295 + AvgRating.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ReferenceOnVideo);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime?>.Default.GetHashCode(DateCreate);
            return hashCode;
        }
    }
}