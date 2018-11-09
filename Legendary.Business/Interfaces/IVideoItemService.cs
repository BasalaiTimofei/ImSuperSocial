using System.Collections.Generic;
using Legendary.Business.Models.Video;

namespace Legendary.Business.Interfaces
{
    public interface IVideoItemService
    {
        VideoItemDto GetVideoItem(string id);
        VideoItemDto UpdateVideoItem(VideoItemDto videoItem);
        void Dispose();
    }
}
