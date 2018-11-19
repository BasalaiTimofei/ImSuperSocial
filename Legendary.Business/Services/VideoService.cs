using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Legendary.Business.Interfaces;
using Legendary.Business.Models.Video;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Services
{
    public class VideoService : IVideoService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public VideoService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public void Create(VideoFullModel video)
        {
            //TODO Проверить роль (тк. FullModel может видеть только адм, модер)

            if (video == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            video.Id = Guid.NewGuid().ToString();

            _uow.VideoRepository.Create(_mapper.Map<VideoDb>(video));

            _uow.Save();
        }

        /// <inheritdoc/>
        public VideoFullModel Get_FullModel(string id)
        {
            //TODO Проверить роль (тк. FullModel может видеть только адм, модер)

            if (id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dbVideo = _uow.VideoRepository.Get(id);
            if (dbVideo == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return _mapper.Map<VideoDb, VideoFullModel>(dbVideo);
        }

        /// <inheritdoc/>
        public List<VideoFullModel> GetAll_FullModel()
        {
            //TODO Проверить роль (тк. FullModel может видеть только адм, модер)

            var dbVideo = _uow.VideoRepository.GetAll();
            if (dbVideo == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = dbVideo.Select(s => _mapper.Map<VideoFullModel>(s)).ToList();

            return dtoVideo;
        }

        /// <inheritdoc/>
        public void Delete(string id)
        {
            //TODO Проверить роль (тк. FullModel может видеть только адм, модер)

            if (id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            _uow.VideoRepository.Delete(id);
            _uow.Save();
        }

        /// <inheritdoc/>
        public void Update(string videoId, VideoFullModel video)
        {
            //TODO Проверить роль (тк. FullModel может видеть только адм, модер)

            if (video == null || videoId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            if (!VidoIsInDb(p => string.Equals(p.Id, video.Id, StringComparison.CurrentCultureIgnoreCase),
                    out var videoDb))
                //TODO Вернуть ошибку о том что такой продукт есть
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            _uow.VideoRepository.Update(_mapper.Map<VideoDb>(video));
            _uow.Save();
        }

        /// <inheritdoc/>
        public VideoItemModel Get_ItemModel(string id)
        {
            var video = _uow.VideoRepository.Get(id);
            if (video == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return _mapper.Map<VideoDb, VideoItemModel>(video);
        }

        /// <inheritdoc/>
        public VideoItemModel GetRandom_ItemModel()
        {
            var dbVideo = _uow.VideoRepository.GetAll().ToArray();

            if (dbVideo.Length == 0)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var video = dbVideo[new Random().Next(0, dbVideo.Length)];

            return _mapper.Map<VideoDb, VideoItemModel>(video);
        }

        /// <inheritdoc/>
        public List<VideoSmallModel> GetAll_SmallModel()
        {
            var dbVideo = _uow.VideoRepository.GetAll();
            if (dbVideo == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = dbVideo.Select(s => _mapper.Map<VideoSmallModel>(s)).ToList();

            return dtoVideo;
        }

        /// <inheritdoc/>
        public VideoSmallModel Get_SmallModel(string id)
        {
            if (id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();
            var video = _uow.VideoRepository.Get(id);
            if (video == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return _mapper.Map<VideoDb, VideoSmallModel>(video);
        }

        /// <inheritdoc/>
        public List<VideoSmallModel> Get_ByActor_SmallModel(string actorId)
        {
            if (actorId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            if (!VidoIsInDb(s =>
                s.Actor.Select(e => string.Equals(e.Id, actorId, StringComparison.InvariantCultureIgnoreCase))
                    .First(), out var video))
                //TODO Вернуть экс с пояснением что такого видео нет.(Или проверять на Фронте).
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = video.Select(s => _mapper.Map<VideoSmallModel>(s)).ToList();

            return dtoVideo;
        }

        /// <inheritdoc/>
        public List<VideoSmallModel> Get_ByCategory_SmallModel(string categoryId)
        {
            if (categoryId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            if (!VidoIsInDb(s =>
                s.Categories.Select(e => string.Equals(e.Id, categoryId, StringComparison.InvariantCultureIgnoreCase))
                    .First(), out var video))

                //TODO Вернуть экс с пояснением что такого видео нет.(Или проверять на Фронте).
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = video.Select(s => _mapper.Map<VideoSmallModel>(s)).ToList();

            return dtoVideo;
        }

        /// <inheritdoc/>
        public List<VideoSmallModel> Get_ByStudio_SmallModel(string studioId)
        {
            if (studioId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            if (!VidoIsInDb(s => string.Equals(s.Studio.Id, studioId, StringComparison.InvariantCultureIgnoreCase),
                    out var video))
                //TODO Вернуть экс с пояснением что такого видео нет.(Или проверять на Фронте).
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = video.Select(s => _mapper.Map<VideoSmallModel>(s)).ToList();

            return dtoVideo;
        }

        /// <inheritdoc/>
        public VideoSmallModel GetRandom_SmallModel()
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

        ~ VideoService()
        {
            Dispose();
        }

        private bool VidoIsInDb(Predicate<VideoDb> condition, out IEnumerable<VideoDb> video)
        {
            video = _uow.VideoRepository.Find(condition);
            return video.Any();
        }
    }
}
