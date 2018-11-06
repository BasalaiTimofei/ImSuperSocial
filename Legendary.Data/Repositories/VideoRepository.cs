﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Legendary.Data.Context;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Repositories
{
    public class VideoRepository : IRepository<VideoDb>
    {
        private readonly LegendaryContext _legendaryContext;
        public VideoRepository(LegendaryContext legendaryContext)
        {
            _legendaryContext = legendaryContext;
        }

        public IEnumerable<VideoDb> GetAll()
        {
            return _legendaryContext.Video.ToList();
        }

        public VideoDb Get(string id)
        {
            return _legendaryContext.Video.Find(id);
        }

        public IEnumerable<VideoDb> Find(Func<VideoDb, bool> predicate)
        {
            return _legendaryContext.Video.Where(predicate).ToList();
        }

        public void Create(VideoDb video)
        {
            video.DateCreate = DateTime.Now;
            _legendaryContext.Video.Add(video);
        }

        public void Update(VideoDb video)
        {
            _legendaryContext.Entry(video).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            var video = _legendaryContext.Video.Find(id);
            if (video != null)
                _legendaryContext.Video.Remove(video);
        }
    }
}
