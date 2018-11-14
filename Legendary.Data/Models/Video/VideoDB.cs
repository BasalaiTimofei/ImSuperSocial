using System;
using System.Collections.Generic;
using Legendary.Data.Models.Actor;
using Legendary.Data.Models.Rating;
using Legendary.Data.Models.Studio;

namespace Legendary.Data.Models.Video
{
    /// <summary>
    /// Video DataBase model.
    /// </summary>
    public class VideoDb
    {
        /// <summary>
        /// Gets or sets a video Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets a video Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets collection video Categories.
        /// </summary>
        public virtual ICollection<CategoryDb> Categories { get; set; }
        /// <summary>
        /// Gets or sets collection video Rating.
        /// </summary>
        public virtual ICollection<VideoRatingDb> Rating { get; set; }
        /// <summary>
        /// Gets or sets collection video Commets.
        /// </summary>
        public virtual ICollection<CommentDb> Comments { get; set; }
        /// <summary>
        /// Gets or sets collection Actors.
        /// </summary>
        public virtual ICollection<ActorDb> Actor { get; set; }
        /// <summary>
        /// Gets or sets Studio.
        /// </summary>
        public virtual StudioDb Studio { get; set; }

        /// <summary>
        /// Gets or sets reference on Video.
        /// </summary>
        public string ReferenceOnVideo { get; set; }
        /// <summary>
        /// Gets or sets Date added video
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Gets or sets reference image for video
        /// </summary>
        public string ImgLink { get; set; }
        /// <summary>
        /// Gets or sets reference gif for video
        /// </summary>
        public string GifLink { get; set; }

        public override bool Equals(object obj)
        {
            var db = obj as VideoDb;
            return db != null &&
                   Id == db.Id &&
                   Name == db.Name &&
                   EqualityComparer<ICollection<CategoryDb>>.Default.Equals(Categories, db.Categories) &&
                   EqualityComparer<ICollection<VideoRatingDb>>.Default.Equals(Rating, db.Rating) &&
                   EqualityComparer<ICollection<CommentDb>>.Default.Equals(Comments, db.Comments) &&
                   EqualityComparer<ICollection<ActorDb>>.Default.Equals(Actor, db.Actor) &&
                   ReferenceOnVideo == db.ReferenceOnVideo &&
                   DateCreate == db.DateCreate &&
                   ImgLink == db.ImgLink &&
                   GifLink == db.GifLink;
        }

        public override int GetHashCode()
        {
            var hashCode = -1097211772;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<CategoryDb>>.Default.GetHashCode(Categories);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<VideoRatingDb>>.Default.GetHashCode(Rating);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<CommentDb>>.Default.GetHashCode(Comments);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<ActorDb>>.Default.GetHashCode(Actor);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ReferenceOnVideo);
            hashCode = hashCode * -1521134295 + DateCreate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ImgLink);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GifLink);
            return hashCode;
        }
    }
}