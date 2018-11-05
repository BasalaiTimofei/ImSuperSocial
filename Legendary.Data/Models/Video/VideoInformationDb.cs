using System;
using System.Collections.Generic;

namespace Legendary.Data.Models.Video
{
    public class VideoInformationDb
    {
        public string InformationId { get; set; }
        public string VideoId { get; set; }
        public string Link { get; set; }
        public IEnumerable<string> CategoriesId { get; set; }
        public IEnumerable<string> CommentsId { get; set; }
        public DateTime DateCreate { get; set; }
    }
}