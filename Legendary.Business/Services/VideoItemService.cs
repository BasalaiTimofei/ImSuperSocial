using System;
using AutoMapper;
using Legendary.Business.Interfaces;
using Legendary.Business.Models.Video;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Services
{
    public class VideoItemService : IVideoItemService
    {
        private readonly IUnitOfWork _uow;
        public VideoItemService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public VideoItemDto GetVideoItem(string id)
        {
            var video = _uow.VideoRepository.Get(id);
            if (video == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return Mapper.Map<VideoDb, VideoItemDto>(video);
        }

        public VideoItemDto UpdateVideoItem(string videoId, VideoItemDto videoItem)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
