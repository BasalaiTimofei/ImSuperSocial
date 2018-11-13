using System.Collections.Generic;
using Legendary.Business.Models.Video;
using Legendary.Data.Models.Actor;

namespace Legendary.Business.Models
{
    public class ActorDto
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
        public Gender Gender { get; set; }

        public override bool Equals(object obj)
        {
            var dto = obj as ActorDto;
            return dto != null &&
                   Id == dto.Id &&
                   Name == dto.Name &&
                   ImgLink == dto.ImgLink &&
                   Gender == dto.Gender;
        }

        public override int GetHashCode()
        {
            var hashCode = -199441574;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ImgLink);
            hashCode = hashCode * -1521134295 + Gender.GetHashCode();
            return hashCode;
        }
    }
}
