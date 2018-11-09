using Legendary.Data.Models.User;

namespace Legendary.Data.Models.Video
{
    public class RatingDb
    {
        public string Id { get; set; }
        public virtual UserDb User { get; set; }
        public virtual VideoDb Video { get; set; }
        public sbyte Rating { get; set; }
    }
}