using System;
using System.Collections.Generic;

namespace Legendary.Data.Models.Video
{
    public class VideoInformationDb
    {
        public string Id { get; set; }
        public virtual VideoDb Video { get; set; }
        public string Link { get; set; }
        public virtual IEnumerable<CommentDb> Comments { get; set; }
        public DateTime DateCreate { get; set; }
    }
}