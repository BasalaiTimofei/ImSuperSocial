using Legendary.Data.Interfaces;

namespace Legendary.Business.BusinessModel
{
    public class AvgRating
    {
        private readonly string _videoId;
        private readonly IUnitOfWork _uow;

        public AvgRating(string videoId, IUnitOfWork uow)
        {
            _videoId = videoId;
            _uow = uow;
        }

        //public double GetAvgRating()
        //{
        //    var rat = _uow.VideoRepository.
        //    return 
        //}
    }
}
