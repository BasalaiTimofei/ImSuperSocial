using Legendary.Data.Models.User;

namespace Legendary.Data.Models.Video
{
    public class RatingDb
    {
        public string Id { get; set; }
        public UserDb User { get; set; }
        public VideoDb Video { get; set; }
        public sbyte Rating { get; set; }
    }
}