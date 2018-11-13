﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Legendary.Business.Interfaces;
using Legendary.Business.Models.Video;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Video;

namespace Legendary.Business.Services.Video
{
    public class VideoService : IVideoService, IDisposable
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public VideoService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            _uow = uow;
        }

        /// <inheritdoc/>
        public VideoFullModel CreateVideo(VideoFullModel video)
        {
            //TODO Проверить роль

            if (video == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            video.Id = Guid.NewGuid().ToString();
            _uow.VideoRepository.Create(_mapper.Map<VideoDb>(video));

            var dbVideo = _uow.VideoRepository.Get(video.Id);
            if (dbVideo == null)
                //TODO Вернуть ошибку создания в репозитории.
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            _uow.Save();
            return _mapper.Map<VideoDb, VideoFullModel>(dbVideo);
        }

        /// <inheritdoc/>
        public VideoFullModel GetVideo(string id)
        {
            //TODO Проверить роль

            if (id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dbVideo = _uow.VideoRepository.Get(id);
            if (dbVideo == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            return _mapper.Map<VideoDb, VideoFullModel>(dbVideo);
        }

        /// <inheritdoc/>
        public List<VideoFullModel> GetListVideo()
        {
            //TODO Проверить роль

            var dbVideo = _uow.VideoRepository.GetAll();
            if (dbVideo == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dtoVideo = dbVideo.Select(s => _mapper.Map<VideoFullModel>(s)).ToList();

            return dtoVideo;
        }

        /// <inheritdoc/>
        public void DeleteVideo(string id)
        {            
            //TODO Проверить роль

            if (id == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            _uow.VideoRepository.Delete(id);
            _uow.Save();
        }

        /// <inheritdoc/>
        public VideoFullModel UpdateVideo(string videoId, VideoFullModel video)
        {
            //TODO Проверить роль

            if (video == null || videoId == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();

            var dbVideo = _uow.VideoRepository.Get(videoId);
            if (dbVideo == null)
                throw new NullReferenceException();//RequestedResourceNotFoundException();
            video.Id = videoId;

            _uow.VideoRepository.Update(_mapper.Map<VideoDb>(video));
            _uow.Save();

            return video;
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}