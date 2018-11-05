using System;
using Legendary.Data.Models.User;

namespace Legendary.Data.Models.Video
{
    public class CommentDb
    {
        public string Id { get; set; }
        public virtual UserDb User { get; set; }
        public virtual VideoInformationDb VideoInformation { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
