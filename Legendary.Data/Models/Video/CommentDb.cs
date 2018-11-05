using System;

namespace Legendary.Data.Models.Video
{
    public class CommentDb
    {
        public string CommentId { get; set; }
        public string UserId { get; set; }
        public string VideoId { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
