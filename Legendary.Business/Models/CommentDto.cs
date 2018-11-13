using System;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            var dto = obj as CommentDto;
            return dto != null &&
                   Id == dto.Id &&
                   UserId == dto.UserId &&
                   VideoId == dto.VideoId &&
                   Comment == dto.Comment &&
                   DateCreate == dto.DateCreate;
        }

        public override int GetHashCode()
        {
            var hashCode = -1206608561;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VideoId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Comment);
            hashCode = hashCode * -1521134295 + DateCreate.GetHashCode();
            return hashCode;
        }
    }
}