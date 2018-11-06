using System;
using System.Collections.Generic;

namespace Legendary.Business.Models.Video
{
    public class VideoFullModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryDto> Categories { get; set; }
        public double Rating { get; set; }

        public string ReferenceOnVideo { get; set; }
        public DateTime DateCreate { get; set; }

        public string ImgLink { get; set; }
        public string GifLink { get; set; }
    }
}