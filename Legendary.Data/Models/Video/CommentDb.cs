using System;
using Legendary.Data.Models.User;

namespace Legendary.Data.Models.Video
{
    public class CommentDb
    {
        /// <summary>
        /// Gets or sets Id comments;
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Name comments;
        /// </summary>
        public virtual UserDb User { get; set; }
        /// <summary>
        /// Gets or sets Video;
        /// </summary>
        public virtual VideoDb Video { get; set; }
        /// <summary>
        /// Gets or sets Comment;
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Gets or sets Date Create Comment
        /// </summary>
        public DateTime DateCreate { get; set; }
    }
}
