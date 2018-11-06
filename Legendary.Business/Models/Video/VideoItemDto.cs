using System;
using System.Collections.Generic;

namespace Legendary.Business.Models.Video
{
    public class VideoItemDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CategoryDto> Categories { get; set; }
        public byte Rating { get; set; }
        public string ReferenceOnVideo { get; set; }
        public DateTime DateCreate { get; set; }
    }
}