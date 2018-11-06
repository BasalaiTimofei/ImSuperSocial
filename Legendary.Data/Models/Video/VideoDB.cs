using System;
using System.Collections.Generic;

namespace Legendary.Data.Models.Video
{
    public class VideoDb
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryDb> Categories { get; set; }
        public byte Rating { get; set; }
        //public VideoImgDb Img { get; set; }

        public string ReferenceOnVideo { get; set; }
        public virtual ICollection<CommentDb> Comments { get; set; }
        public DateTime DateCreate { get; set; }

        public string ImgLink { get; set; }
        public string GifLink { get; set; }
    }

    /*public class VideoImgDb
    {
        public int Id { get; set; }
        public string ImgLink { get; set; }
        public string GifLink { get; set; }
        public VideoDb Video { get; set; }
    }*/
}