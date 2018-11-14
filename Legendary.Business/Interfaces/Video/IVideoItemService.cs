using System;
using Legendary.Business.Models.Video;

namespace Legendary.Business.Interfaces.Video
{
    public interface IVideoItemService : IDisposable
    {
        /// <summary>
        /// Get a video by Id.
        /// </summary>
        /// <param name="id">Id video.</param>
        /// <returns>A <see cref="VideoItem"/></returns>
        VideoItem GetVideoItem(string id);
    }
}