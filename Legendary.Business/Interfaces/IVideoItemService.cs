using System.Collections.Generic;
using Legendary.Business.Models.Video;

namespace Legendary.Business.Interfaces
{
    public interface IVideoItemService
    {
        /// <summary>
        /// Get a video by Id.
        /// </summary>
        /// <param name="id">Id video.</param>
        /// <returns>A <see cref="VideoItemDto"/></returns>
        VideoItemDto GetVideoItem(string id);
        /// <summary>
        /// Update video.
        /// </summary>
        /// <param name="videoId">Id Video.</param>
        /// <param name="videoItem">Model video.</param>
        /// <returns>A <see cref="VideoItemDto"/></returns>
        VideoItemDto UpdateVideoItem(string videoId, VideoItemDto videoItem);
        /// <summary>
        /// Dispose
        /// </summary>
        void Dispose();
    }
}