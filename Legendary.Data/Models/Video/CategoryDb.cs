using System.Collections.Generic;

namespace Legendary.Data.Models.Video
{
    public class CategoryDb
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> VideoId { get; set; }
    }
}
