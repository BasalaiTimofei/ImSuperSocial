using System;
using System.Collections.Generic;

namespace Legendary.Business.Models
{
    /// <summary>
    /// CommentDataTransferObject model.
    /// </summary>
     public class Comment
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
        public string TextComment { get; set; }
        /// <summary>
        /// Gets or sets Date Create Comment.
        /// </summary>
        public DateTime DateCreate { get; set; }

        public override bool Equals(object obj)
        {
            var comment = obj as Comment;
            return comment != null &&
                   Id == comment.Id &&
                   UserId == comment.UserId &&
                   VideoId == comment.VideoId &&
                   TextComment == comment.TextComment &&
                   DateCreate == comment.DateCreate;
        }

        public override int GetHashCode()
        {
            var hashCode = 975659628;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VideoId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TextComment);
            hashCode = hashCode * -1521134295 + DateCreate.GetHashCode();
            return hashCode;
        }
    }
}