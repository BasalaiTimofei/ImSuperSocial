using System.Collections.Generic;
using Legendary.Business.Models.Video;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Models
{
    public class CategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<VideoDb> Video { get; set; }
    }
}