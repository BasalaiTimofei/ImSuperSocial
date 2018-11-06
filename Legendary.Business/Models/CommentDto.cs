using System;

namespace Legendary.Business.Models
{
    public class CommentDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string VideoId { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreate { get; set; }
    }
}