using System.Collections.Generic;
using Legendary.Business.Models.Video;

namespace Legendary.Business.Models
{
    public class CategoryDto
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var dto = obj as CategoryDto;
            return dto != null &&
                   Id == dto.Id &&
                   Name == dto.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -1919740922;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}