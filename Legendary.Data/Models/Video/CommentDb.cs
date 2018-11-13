using System;
using System.Collections.Generic;
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

        public override bool Equals(object obj)
        {
            var db = obj as CommentDb;
            return db != null &&
                   Id == db.Id &&
                   EqualityComparer<UserDb>.Default.Equals(User, db.User) &&
                   EqualityComparer<VideoDb>.Default.Equals(Video, db.Video) &&
                   Comment == db.Comment &&
                   DateCreate == db.DateCreate;
        }

        public override int GetHashCode()
        {
            var hashCode = 1142500709;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<UserDb>.Default.GetHashCode(User);
            hashCode = hashCode * -1521134295 + EqualityComparer<VideoDb>.Default.GetHashCode(Video);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Comment);
            hashCode = hashCode * -1521134295 + DateCreate.GetHashCode();
            return hashCode;
        }
    }
}
