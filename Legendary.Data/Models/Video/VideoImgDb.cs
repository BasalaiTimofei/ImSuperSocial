using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary.Data.Models.Video
{
    public class VideoImgDb
    {
        public string Id { get; set; }
        public string ImgLink { get; set; }
        public string GifLink { get; set; }
        public virtual VideoDb Video { get; set; }
    }
}
