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
    public class VideoListService : IVideoListService
    {
        private readonly IUnitOfWork _uow;
        public VideoListService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<VideoListDto> GetAllVideoList()
        {
            var dbVideo = _uow.VideoRepository.GetAll();
            var dtoVideo = dbVideo.Select(s => Mapper.Map<VideoListDto>(s)).ToList();

            _uow.Save();
            return dtoVideo;
        }

        public VideoListDto GetVideoList(string id)
        {
            var video = _uow.VideoRepository.Get(id);
            if (video == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            _uow.Save();
            return Mapper.Map<VideoDb, VideoListDto>(video);
        }

        public VideoListDto GetRandomVideoList()
        {
            var dbVideo = _uow.VideoRepository.GetAll().ToArray();
            if (dbVideo.Length == 0)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var video = dbVideo[new Random().Next(0, dbVideo.Count())];

            _uow.Save();
            return Mapper.Map<VideoDb, VideoListDto>(video);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
