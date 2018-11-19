using System;
using System.Collections.Generic;
using AutoMapper;
using Legendary.Business.Infrastructure.Mapping;
using Legendary.Business.Models;
using Legendary.Business.Models.Studio;
using Legendary.Business.Services;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Actor;
using Legendary.Data.Models.Country;
using Legendary.Data.Models.Rating;
using Legendary.Data.Models.Studio;
using Legendary.Data.Models.Video;
using Moq;
using NUnit.Framework;

namespace Legendary.Business.Tests.Tests
{
    public class StudioServiceTests
    {
        private Mapper _mapper;
        private MapperConfiguration _configuration;
        private Mock<IUnitOfWork> _mockUow;

        private ICollection<StudioDb> _selectCollectionStudio;
        private CountryDb _countryDb;
        private StudioDb _studioDb;
        private StudioFullModel _studioFullModel;

        [SetUp]
        public void SetUpMethod()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ActorMappingProfile());
                cfg.AddProfile(new CategoryMappingProfile());
                cfg.AddProfile(new CountryMappingProfile());
                cfg.AddProfile(new CommentMappingProfile());
                cfg.AddProfile(new VideoMappingProfile());
                cfg.AddProfile(new StudioMappingProfile());
            });
            _mapper = new Mapper(_configuration);
            _mockUow = new Mock<IUnitOfWork>();

            _countryDb = new CountryDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "CountryName",
                Studio = new List<StudioDb>(),
                Actors = new List<ActorDb>()
            };

            _studioDb = new StudioDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "StudioName",
                ImgLink = "StudioImg",
                Video = new List<VideoDb>(),
                Rating = new List<StudioRatingDb>(),
                Cauntry = new CountryDb()
            };

            _studioFullModel = new StudioFullModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "StudioName",
                ImgLink = "StudioImg",
                AvgRating = 50,
                Country = new Country()
            };

            _selectCollectionStudio = new List<StudioDb>();
        }

        [Test]
        public void AddStudio_CellMethod()
        {
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                service.Create(_studioFullModel);

                _mockUow.Verify(v => v.StudioRepository.Create(It.IsAny<StudioDb>()), Times.Once);
            }
        }

        [Test]
        public void AddStudio_BadArgument_Return_Exception()
        {
            _selectCollectionStudio.Add(_studioDb);
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Create(_studioFullModel));
                
                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void AddStudio_NotAdmin_Return_Exception()
        {

        }

        [Test]
        public void DeleteStudio_CellMethod()
        {
            var id = Guid.NewGuid().ToString();
            _studioDb.Id = id;
            _selectCollectionStudio.Add(_studioDb);
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                service.Delete(id);

                _mockUow.Verify(v => v.StudioRepository.Delete(id), Times.Once);
            }
        }


        [Test]
        public void DeleteStudio_BadArgument_Return_Exception()
        {
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Delete(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void DeleteStudio_GoodArgument_Return_Null_Exception()
        {
            _selectCollectionStudio = null;
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Delete(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void DeleteStudio_NotAdmmin_Return_Exception()
        {

        }

        [Test]
        public void UpdateStudio_CellMethod()
        {
            _selectCollectionStudio.Add(_studioDb);
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                service.Update(_studioDb.Id, _studioFullModel);

                _mockUow.Verify(v => v.StudioRepository.Update(It.IsAny<StudioDb>()), Times.Once);
            }
        }

        [Test]
        public void UpdateStudio_BadArgument_AnyId_Return_Exception()
        {
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Update(It.IsAny<string>(), It.IsAny<StudioFullModel>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void UpdateStudio_BadArgument_NullId_Return_Exception()
        {
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Update(null, It.IsAny<StudioFullModel>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void UpdateStudio_BadArgument_Model_Return_Exception()
        {
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Update(It.IsAny<string>(), null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void UpdateStudio_NotAdmin_Return_Exception()
        {

        }

        [Test]
        public void GetStudio_ById_Get_GoodId_Return_StudioFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.StudioRepository.Get(id))
                .Returns(_studioDb);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = service.Get_FullModel(id);

                Assert.That(result, Is.TypeOf<StudioFullModel>());
            }
        }

        [Test]
        public void GetStudio_ById_Get_GoodId_Return_Null_Exception_StudioFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _studioDb = null;
            _mockUow.Setup(s => s.StudioRepository.Get(id))
                .Returns(_studioDb);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Get_FullModel(id));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetStudio_ById_Get_AnyId_Return_Null_Exception_StudioFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.StudioRepository.Get(id))
                .Returns(_studioDb);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Get_FullModel(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetStudio_ById_Get_NullId_Return_Exception_StudioFullModel()
        {
            _mockUow.Setup(s => s.StudioRepository.Get(It.IsAny<string>()))
                .Returns(_studioDb);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Get_FullModel(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetAllStudio_Return_StudioFullModel()
        {
            _selectCollectionStudio.Add(_studioDb);
            _mockUow.Setup(s => s.StudioRepository.GetAll())
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_FullModel();

                Assert.That(result, Is.TypeOf<List<StudioFullModel>>());
            }
        }

        public void GetAllStudio_Return_OneStudio_StudioFullModel()
        {
            _selectCollectionStudio.Add(_studioDb);
            _mockUow.Setup(s => s.StudioRepository.GetAll())
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_FullModel();

                Assert.That(result.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void GetAllStudio_Return_TwoStudio_StudioFullModel()
        {
            _selectCollectionStudio.Add(_studioDb);
            _selectCollectionStudio.Add(new StudioDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "StudioName",
                ImgLink = "StudioImg",
                Video = new List<VideoDb>(),
                Rating = new List<StudioRatingDb>(),
                Cauntry = new CountryDb()
            });
            _mockUow.Setup(s => s.StudioRepository.GetAll())
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_FullModel();

                Assert.That(result.Count, Is.EqualTo(2));
            }
        }

        [Test]
        public void GetAllStudio_Return_Null_Exception_StudioFullModel()
        {
            _selectCollectionStudio = null;
            _mockUow.Setup(s => s.StudioRepository.GetAll())
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.GetAll_FullModel());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetStudio_ByCountryId_GetGoodId_Return_StudioFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _selectCollectionStudio.Add(_studioDb);
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_By_Country_FullModel(id);

                Assert.That(result, Is.TypeOf<List<StudioFullModel>>());
            }
        }

        [Test]
        public void GetStudio_ByCountryId_GetGoodId_Return_OneStudio_StudioFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _countryDb.Id = id;
            _selectCollectionStudio.Add(new StudioDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "StudioName",
                ImgLink = "StudioImg",
                Video = new List<VideoDb>(),
                Rating = new List<StudioRatingDb>(),
                Cauntry = _countryDb
            });
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_By_Country_FullModel(id);

                Assert.That(result.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void GetStudio_ByCountryId_GetGoodId_Return_TwoStudio_StudioFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _countryDb.Id = id;
            _selectCollectionStudio.Add(new StudioDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "StudioName",
                ImgLink = "StudioImg",
                Video = new List<VideoDb>(),
                Rating = new List<StudioRatingDb>(),
                Cauntry = _countryDb
            });
            _selectCollectionStudio.Add(new StudioDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "StudioName",
                ImgLink = "StudioImg",
                Video = new List<VideoDb>(),
                Rating = new List<StudioRatingDb>(),
                Cauntry = _countryDb
            });
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_By_Country_FullModel(id);

                Assert.That(result.Count, Is.EqualTo(2));
            }
        }

        [Test]
        public void GetStudio_ByCountryId_AnyId_Return_Null_Exception_StudioFullModel()
        {
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.GetAll_By_Country_FullModel(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetStudio_ByCountryId_GetNullId_Return_Null_Exception_StudioFullModel()
        {
            _selectCollectionStudio = null;
            _mockUow.Setup(s => s.StudioRepository.Find(It.IsAny<Predicate<StudioDb>>()))
                .Returns(_selectCollectionStudio);

            using (var service = new StudioService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.GetAll_By_Country_FullModel(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }
    }
}