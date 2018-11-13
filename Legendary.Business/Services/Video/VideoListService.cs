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

        public List<VideoListDto> GetAllVideoList()
        {
            var dbVideo = _uow.VideoRepository.GetAll();
            if (dbVideo == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = dbVideo.Select(s => _mapper.Map<VideoListDto>(s)).ToList();

            return dtoVideo;
        }

        public VideoListDto GetVideoList(string id)
        {
            if (id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();
            var video = _uow.VideoRepository.Get(id);
            if (video == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return _mapper.Map<VideoDb, VideoListDto>(video);
        }

        public List<VideoListDto> GetVideoByActor(string actorId)
        {
            //TODO Спросить у Саши как это написать через VideoRepository
            if (actorId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dbVideo = _uow.ActorRepository.Get(actorId).Video.ToList();

            var dtoVideo = dbVideo.Select(s => _mapper.Map<VideoListDto>(s)).ToList();

            return dtoVideo;
        }

        public VideoListDto GetRandomVideoList()
        {
            var dbVideo = _uow.VideoRepository.GetAll().ToArray(); 
            //TODO Спросить у Саши нужна ли тут проверка
            /* 
                != null 
                ? _uow.VideoRepository.GetAll().ToArray()
                : throw new NullReferenceException();//RequestedResourceNotFoundException();
            */
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
