using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Legendary.Business.Interfaces.Video;
using Legendary.Business.Models.Video;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Services.Video
{
    public class VideoListService : IVideoListService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public VideoListService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        /// <inheritdoc/>
        public List<VideoSmallModel> GetAllVideoList()
        {
            var dbVideo = _uow.VideoRepository.GetAll();
            if (dbVideo == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = dbVideo.Select(s => _mapper.Map<VideoSmallModel>(s)).ToList();

            return dtoVideo;
        }

        /// <inheritdoc/>
        public VideoSmallModel GetVideoList(string id)
        {
            if (id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();
            var video = _uow.VideoRepository.Get(id);
            if (video == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return _mapper.Map<VideoDb, VideoSmallModel>(video);
        }

        /// <inheritdoc/>
        public List<VideoSmallModel> GetVideoByActor(string actorId)
        {
            if (actorId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dbVideo = _uow.VideoRepository.GetAll().Where(a => a.Actor
                .Select(s => string.Equals(s.Id, actorId, StringComparison.InvariantCultureIgnoreCase))
                    .First()).ToList();

            /*
            if (VidoIsInDb(s =>
                s.Actor.Select(e => string.Equals(e.Id, actorId, StringComparison.InvariantCultureIgnoreCase))
                    .First(), out var videoDb))
            */

            if (dbVideo.Count == 0)
                //TODO Вернуть экс с пояснением что такого видео нет.(Или проверять на Фронте).
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = dbVideo.Select(s => _mapper.Map<VideoSmallModel>(s)).ToList();

            return dtoVideo;
        }

        /// <inheritdoc/>
        public List<VideoSmallModel> GetVideoByCategory(string categoryId)
        {
            if (categoryId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dbVideo = _uow.VideoRepository.GetAll().Where(a => a.Categories
                .Select(s => string.Equals(s.Id, categoryId, StringComparison.InvariantCultureIgnoreCase))
                .First()).ToList();

            /*
            if (VidoIsInDb(s =>
                s.Categories.Select(e => string.Equals(e.Id, categoryId, StringComparison.InvariantCultureIgnoreCase))
                    .First(), out var videoDb))
            */

            if (dbVideo.Count == 0)
                //TODO Вернуть экс с пояснением что такого видео нет.(Или проверять на Фронте).
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = dbVideo.Select(s => _mapper.Map<VideoSmallModel>(s)).ToList();

            return dtoVideo;
        }

        /// <inheritdoc/>
        public List<VideoSmallModel> GetVideoByStudio(string studioId)
        {
            if (studioId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();
            var vid = _uow.VideoRepository.GetAll();
            var video = _uow.VideoRepository.GetAll().Where(w =>
                string.Equals(w.Studio.Id, studioId, StringComparison.InvariantCultureIgnoreCase)).ToList();
            /*
            if (VidoIsInDb(s => string.Equals(s.Studio.Id, studioId, StringComparison.InvariantCultureIgnoreCase), out var videoDb))
            */

                if (video.Count == 0)
                //TODO Вернуть экс с пояснением что такого видео нет.(Или проверять на Фронте).
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = video.Select(s => _mapper.Map<VideoSmallModel>(s)).ToList();

            return dtoVideo;

        }

        /// <inheritdoc/>
        public VideoSmallModel GetRandomVideoList()
        {
            var dbVideo = _uow.VideoRepository.GetAll().ToArray(); 
            
            if (dbVideo.Length == 0)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var video = dbVideo[new Random().Next(0, dbVideo.Length)];

            return _mapper.Map<VideoDb, VideoSmallModel>(video);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        private bool VidoIsInDb(Predicate<VideoDb> condition, out IEnumerable<VideoDb> video)
        {
            video = _uow.VideoRepository.Find(condition);
            return video.Any();
        }
    }
}
