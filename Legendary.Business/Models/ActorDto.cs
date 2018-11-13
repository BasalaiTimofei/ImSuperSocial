using System.Collections.Generic;
using Legendary.Business.Models.Video;
using Legendary.Data.Models.Actor;

namespace Legendary.Business.Models
{
    public class ActorDto
    {
        /// <summary>
        /// Gets or sets actor Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets actor Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets reference on image with cator.
        /// </summary>
        public string ImgLink { get; set; }
        /// <summary>
        /// Gets or sets actor gender.
        /// </summary>
        public Gender Gender { get; set; }
    }
}
