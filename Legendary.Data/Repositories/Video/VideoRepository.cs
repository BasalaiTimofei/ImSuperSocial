using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Legendary.Data.Context;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Video;

namespace Legendary.Data.Repositories.Video
{
    public class VideoRepository : IRepository<VideoDb>
    {
        private readonly LegendaryContext _legendaryContext;
        public VideoRepository(LegendaryContext legendaryContext)
        {
            _legendaryContext = legendaryContext;
        }

        public async Task<List<VideoDb>> GetAll()
        {
            return await _legendaryContext.Video.ToListAsync();
        }

        public async Task<VideoDb> Get(string id)
        {
            return await _legendaryContext.Video.FirstAsync(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<List<VideoDb>> Find(Predicate<VideoDb> predicate)
        {
            var condition = new Func<VideoDb, bool>(predicate);

            return await Task.Run(() => _legendaryContext.Video.Where(condition).ToList());
        }

        public async Task Create(VideoDb video)
        {
            video.Id = Guid.NewGuid().ToString();
            video.DateCreate = DateTime.Now;
            _legendaryContext.Video.Add(video);
            await _legendaryContext.SaveChangesAsync();
        }

        public async Task Update(VideoDb video)
        {
            _legendaryContext.Entry(video).State = EntityState.Modified;
            await _legendaryContext.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var video = await _legendaryContext.Video.FirstAsync(f =>
                string.Equals(f.Id, id, StringComparison.InvariantCultureIgnoreCase));
            if (video != null)
                _legendaryContext.Video.Remove(video);
            await _legendaryContext.SaveChangesAsync();
        }
    }
}
