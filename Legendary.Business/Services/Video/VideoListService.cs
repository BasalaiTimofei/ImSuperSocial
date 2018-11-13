using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Legendary.Business.Interfaces;
using Legendary.Business.Models.Video;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Services.Video
{
    public class VideoListService : IVideoListService, IDisposable
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public VideoListService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        /// <inheritdoc/>
        public List<VideoListDto> GetAllVideoList()
        {
            var dbVideo = _uow.VideoRepository.GetAll();
            if (dbVideo == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = dbVideo.Select(s => _mapper.Map<VideoListDto>(s)).ToList();

            return dtoVideo;
        }

        /// <inheritdoc/>
        public VideoListDto GetVideoList(string id)
        {
            if (id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();
            var video = _uow.VideoRepository.Get(id);
            if (video == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return _mapper.Map<VideoDb, VideoListDto>(video);
        }

        /// <inheritdoc/>
        public List<VideoListDto> GetVideoByActor(string actorId)
        {
            if (actorId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dbVideo = _uow.VideoRepository.Find(a =>
                    a.Actor.Select(s => string.Equals(s.Id, actorId, StringComparison.CurrentCultureIgnoreCase))
                        .First())
                .ToList();
            if (dbVideo.Count == 0)
                //TODO Вернуть экс с пояснением что такого видео нет.(Или проверять на Фронте).
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = dbVideo.Select(s => _mapper.Map<VideoListDto>(s)).ToList();

            return dtoVideo;
        }

        /// <inheritdoc/>
        public VideoListDto GetRandomVideoList()
        {
            var dbVideo = _uow.VideoRepository.GetAll().ToArray(); 
            
            if (dbVideo.Length == 0)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var video = dbVideo[new Random().Next(0, dbVideo.Length)];

            return _mapper.Map<VideoDb, VideoListDto>(video);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

    }
}
