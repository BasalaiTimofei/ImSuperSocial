using System.Collections.Generic;

namespace Legendary.Data.Models.Video
{
    public class VideoDb
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryDb> Categories { get; set; }
        public virtual VideoInformationDb Information { get; set; }
        public virtual VideoImgDb Img { get; set; }
        public byte Rating { get; set; }
    }
}