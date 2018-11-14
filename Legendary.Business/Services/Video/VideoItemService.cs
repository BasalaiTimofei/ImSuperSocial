using System;
using AutoMapper;
using Legendary.Business.Interfaces.Video;
using Legendary.Business.Models.Video;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Services.Video
{
    public class VideoItemService : IVideoItemService, IDisposable
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public VideoItemService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        /// <inheritdoc/>
        public VideoItemDto GetVideoItem(string id)
        {
            var video = _uow.VideoRepository.Get(id);
            if (video == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return _mapper.Map<VideoDb, VideoItemDto>(video);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
