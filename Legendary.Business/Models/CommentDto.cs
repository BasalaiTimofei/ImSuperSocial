using System;

namespace Legendary.Business.Models
{
    public class CommentDto
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets User Id.
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets Video Id.
        /// </summary>
        public string VideoId { get; set; }
        /// <summary>
        /// Gets or sets Comment.
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Gets or sets Date Create Comment.
        /// </summary>
        public DateTime DateCreate { get; set; }
    }
}