using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Legendary.Business.Interfaces;
using Legendary.Business.Models;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Studio;

namespace Legendary.Business.Services
{
    public class StudioService : IStudioService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public StudioService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public void Create(Studio studioModel)
        {
            throw new NotImplementedException();
        }

        public void Update(string studioId, Studio studioModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(string studioId)
        {
            throw new NotImplementedException();
        }

        public Studio Get(string studioId)
        {
            throw new NotImplementedException();
        }

        public List<Studio> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
        private bool StudioIsInDb(Predicate<StudioDb> condition, out IEnumerable<StudioDb> video)
        {
            video = _uow.StudioRepository.Find(condition);
            return video.Any();
        }
    }
}
