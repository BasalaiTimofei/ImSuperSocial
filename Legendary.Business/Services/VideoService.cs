using System;
using System.Linq;
using AutoMapper;
using Legendary.Business.Interfaces;
using Legendary.Business.Models.Video;
using Legendary.Data.Interfaces;

namespace Legendary.Business.Services
{
    public class VideoService : IVideoService
    {
        private readonly IUnitOfWork _uow;

        public VideoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void CreateVideo(VideoFullModel video)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteVideo(string id)
        {
            //TODO Проверить роль удаляющего(Удалять может только админ, модер)
            _uow.VideoRepository.Delete(id);
        }

        public void UpdateVideo(string videoId, VideoFullModel video)
        {
            var dbVideo = _uow.VideoRepository
                .Find(p => p.Name == video.Name && p.Id != videoId)
                .ToArray();
            if (dbVideo.Length > 0)
                throw new Exception();// Менять имя нельзя

            dbVideo = _uow.VideoRepository.Find(p => p.Id == videoId).ToArray();
            if (dbVideo.Length == 0)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var vid = dbVideo[0];
            _uow.VideoRepository.Update(Mapper.Map(video, vid));
            //TODO Возможно надо что-то возвращать + добавить SaveChangers()
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
