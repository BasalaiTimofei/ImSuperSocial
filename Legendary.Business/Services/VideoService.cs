using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task Create(VideoFullModel video)
        {
            //TODO Плолучить ид того кто добавил.
            //video.Creator = User.Id;
            if (video == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            await _uow.VideoRepository.Create(_mapper.Map<VideoDb>(video));
        }

        /// <inheritdoc/>
        public async Task<VideoFullModel> Get_FullModel(string id)
        {
            //TODO Проверить роль и ид (тк. FullModel может видеть только адм, модер, и тот кто добавил видео)

            if (id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dbVideo = await _uow.VideoRepository.Get(id);
            if (dbVideo == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return _mapper.Map<VideoDb, VideoFullModel>(dbVideo);
        }

        /// <inheritdoc/>
        public async Task<List<VideoFullModel>> GetAll_FullModel()
        {
            //TODO Проверить роль и ид (тк. FullModel может видеть только адм, модер, и тот кто добавил видео)

            var dbVideo = await _uow.VideoRepository.GetAll();
            if (dbVideo == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = dbVideo.Select(s => _mapper.Map<VideoFullModel>(s)).ToList();

            return dtoVideo;
        }

        /// <inheritdoc/>
        public async Task Delete(string id)
        {
            //TODO Проверить роль и ид (тк. FullModel может видеть только адм, модер, и тот кто добавил видео)

            if (id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            await _uow.VideoRepository.Delete(id);
        }

        /// <inheritdoc/>
        public async Task Update(string videoId, VideoFullModel video)
        {
            //TODO Проверить роль и ид (тк. FullModel может видеть только адм, модер, и тот кто добавил видео)

            if (video == null || videoId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            if (!VidoIsInDb(p => string.Equals(p.Id, video.Id, StringComparison.CurrentCultureIgnoreCase),
                    out var videoDb))
                //TODO Вернуть ошибку о том что такой продукт есть
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            await _uow.VideoRepository.Update(_mapper.Map<VideoDb>(video));
        }

        /// <inheritdoc/>
        public async Task<VideoItemModel> Get_ItemModel(string id)
        {
            var video = await _uow.VideoRepository.Get(id);
            if (video == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return _mapper.Map<VideoDb, VideoItemModel>(video);
        }

        /// <inheritdoc/>
        public async Task<VideoItemModel> GetRandom_ItemModel()
        {
            var dbVideo =  await _uow.VideoRepository.GetAll();

            if (dbVideo.Count == 0)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var video = dbVideo[new Random().Next(0, dbVideo.Count)];

            return _mapper.Map<VideoDb, VideoItemModel>(video);
        }

        /// <inheritdoc/>
        public async Task<List<VideoSmallModel>> GetAll_SmallModel()
        {
            var dbVideo = await _uow.VideoRepository.GetAll();
            if (dbVideo == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = dbVideo.Select(s => _mapper.Map<VideoSmallModel>(s)).ToList();

            return dtoVideo;
        }

        /// <inheritdoc/>
        public async Task<VideoSmallModel> Get_SmallModel(string id)
        {
            if (id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();
            var video = await _uow.VideoRepository.Get(id);
            if (video == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return _mapper.Map<VideoDb, VideoSmallModel>(video);
        }

        /// <inheritdoc/>
        public async Task<List<VideoSmallModel>> Get_ByActor_SmallModel(string actorId)
        {
            if (actorId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();
            var video = await _uow.VideoRepository.Find(s =>
                s.Actor.Select(e => string.Equals(e.Id, actorId, StringComparison.InvariantCultureIgnoreCase))
                    .First());
            if (video == null)
                //TODO Вернуть экс с пояснением что такого видео нет.(Или проверять на Фронте).
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return video.Select(s => _mapper.Map<VideoSmallModel>(s)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<VideoSmallModel>> Get_ByCategory_SmallModel(string categoryId)
        {
            if (categoryId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();
            var video = await _uow.VideoRepository.Find(s =>
                s.Categories.Select(e => string.Equals(e.Id, categoryId, StringComparison.InvariantCultureIgnoreCase))
                    .First());
            if (video == null)
                //TODO Вернуть экс с пояснением что такого видео нет.(Или проверять на Фронте).
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return video.Select(s => _mapper.Map<VideoSmallModel>(s)).ToList();
        }

        /// <inheritdoc/>
        public async Task<List<VideoSmallModel>> Get_ByStudio_SmallModel(string studioId)
        {
            if (studioId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();
            var video = await _uow.VideoRepository.Find(
                s => string.Equals(s.Studio.Id, studioId, StringComparison.InvariantCultureIgnoreCase));
            if (video == null)
                //TODO Вернуть экс с пояснением что такого видео нет.(Или проверять на Фронте).
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return video.Select(s => _mapper.Map<VideoSmallModel>(s)).ToList();
        }

        /// <inheritdoc/>
        public async Task<VideoSmallModel> GetRandom_SmallModel()
        {
            var dbVideo = await _uow.VideoRepository.GetAll();

            if (dbVideo.Count == 0)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var video = dbVideo[new Random().Next(0, dbVideo.Count)];

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
            video = _uow.VideoRepository.Find(condition).Result;
            return video.Any();
        }
    }
}
