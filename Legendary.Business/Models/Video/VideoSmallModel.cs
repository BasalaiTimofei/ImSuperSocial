﻿using System.Collections.Generic;

namespace Legendary.Business.Models.Video
{
    /// <summary>
    /// Small model Video
    /// </summary>
    public class VideoSmallModel
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets reference on Video.
        /// </summary>
        public string ImgLink { get; set; }
        /// <summary>
        /// Gets on sets Reference on Video.
        /// </summary>
        public string GifLink { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as VideoSmallModel;
            return model != null &&
                   Id == model.Id &&
                   Name == model.Name &&
                   ImgLink == model.ImgLink &&
                   GifLink == model.GifLink;
        }

        public override int GetHashCode()
        {
            var hashCode = 850154383;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ImgLink);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GifLink);
            return hashCode;
        }
    }
}