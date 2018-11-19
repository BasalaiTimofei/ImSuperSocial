using System;
using System.Collections.Generic;
using AutoMapper;
using Legendary.Business.Infrastructure.Mapping;
using Legendary.Business.Models;
using Legendary.Business.Models.Actor;
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
    [TestFixture]
    public class ActorServiceTests
    {
        private Mapper _mapper;
        private MapperConfiguration _configuration;
        private Mock<IUnitOfWork> _mockUow;

        private ICollection<ActorDb> _selectCollectionActor;
        private CountryDb _countryDb;
        private ActorDb _actorDb;
        private ActorFullModel _actorFullModel;


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

            _actorDb = new ActorDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ActorName",
                ImgLink = "ActorImg",
                Gender = "Gender",
                Video = new List<VideoDb>(),
                Rating = new List<ActorRatingDb>(),
                Country = new CountryDb()
            };

            _actorFullModel = new ActorFullModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ActorName",
                Gender = "Gender",
                ImgLink = "ActorImg",
                AvgRating = 50,
                Country = new Country()
            };

            _selectCollectionActor =new List<ActorDb>();
        }

        [Test]
        public void AddActor_CellMethod()
        {
            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                service.Create(_actorFullModel);

                _mockUow.Verify(v => v.ActorRepository.Create(It.IsAny<ActorDb>()), Times.Once);
            }
        }

        [Test]
        public void AddActor_Get_BadArgument_NotCellMethod()
        {
            _selectCollectionActor.Add(_actorDb);
            _actorFullModel.Name = _actorDb.Name;
            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Create(_actorFullModel));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void AddActor_Get_Null_Return_Exception()
        {
            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Create(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void AddActor_NotAdmin_Return_Exception()
        {

        }

        [Test]
        public void DeleteActor_CellMethod()
        {
            _selectCollectionActor.Add(_actorDb);
            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                service.Delete(_actorDb.Id);

                _mockUow.Verify(v => v.ActorRepository.Delete(It.IsAny<string>()), Times.Once);
            }

        }

        [Test]
        public void DeleteActor_BadArgument_Return_Exception()
        {
            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Delete(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void DeleteActor_NotAdmmin_Return_Exception()
        {

        }

        [Test]
        public void UpdateActor_CellMethod()
        {
            _selectCollectionActor.Add(_actorDb);
            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                service.Update(_actorDb.Id, _actorFullModel);

                _mockUow.Verify(v => v.ActorRepository.Update(It.IsAny<ActorDb>()), Times.Once);
            }
        }

        [Test]
        public void UpdateActor_BadArgument_NullId_Return_Exception()
        {
            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Update(null, _actorFullModel));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void UpdateActor_BadArgument_AnyId_Return_Exception()
        {
            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Update(It.IsAny<string>(), _actorFullModel));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void UpdateActor_BadArgument_NullModel_Return_Exception()
        {
            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Update(_actorDb.Id, null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }

        }

        [Test]
        [Ignore("Watch in a method")]
        public void UpdateActor_NotAdmin_Return_Exception()
        {

        }

        [Test]
        public void GetActor_ById_Get_GoodId_Return_ActorFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _actorDb.Id = id;
            _mockUow.Setup(s => s.ActorRepository.Get(id))
                .Returns(_actorDb);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = service.Get_FullModel(id);

                Assert.That(result, Is.TypeOf<ActorFullModel>());
            }
        }

        [Test]
        public void GetActor_ById_Get_GoodId_Return_Null_Exception_ActorFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _actorDb = null;
            _mockUow.Setup(s => s.ActorRepository.Get(id))
                .Returns(_actorDb);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Get_FullModel(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }

        }

        [Test]
        public void GetActor_ById_Get_AnyId_Return_Null_Exception_ActorFullModel()
        {
            _mockUow.Setup(s => s.ActorRepository.Get(_actorDb.Id))
                .Returns(_actorDb);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Get_FullModel(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }

        }

        [Test]
        public void GetActor_ById_Get_NullId_Return_Exception_ActorFullModel()
        {
            _mockUow.Setup(s => s.ActorRepository.Get(_actorDb.Id))
                .Returns(_actorDb);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Get_FullModel(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetAllActors_Return_Actors_ActorFullModel()
        {
            _selectCollectionActor.Add(_actorDb);
            _mockUow.Setup(s => s.ActorRepository.GetAll())
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_FullModel();

                Assert.That(result, Is.TypeOf<List<ActorFullModel>>());
            }

        }

        [Test]
        public void GetAllActors_Return_OneActors_ActorFullModel()
        {
            _selectCollectionActor.Add(new ActorDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ActorName",
                ImgLink = "ActorImg",
                Gender = "Gender",
                Video = new List<VideoDb>(),
                Rating = new List<ActorRatingDb>(),
                Country = new CountryDb()

            });
            _mockUow.Setup(s => s.ActorRepository.GetAll())
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_FullModel();

                Assert.That(result.Count, Is.EqualTo(1));
            }
        }


        [Test]
        public void GetAllActors_Return_TwoActors_ActorFullModel()
        {
            _selectCollectionActor.Add(new ActorDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ActorName",
                ImgLink = "ActorImg",
                Gender = "Gender",
                Video = new List<VideoDb>(),
                Rating = new List<ActorRatingDb>(),
                Country = new CountryDb()

            });
            _selectCollectionActor.Add(_actorDb);
            _mockUow.Setup(s => s.ActorRepository.GetAll())
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_FullModel();

                Assert.That(result.Count, Is.EqualTo(2));
            }
        }

        [Test]
        public void GetAllActors_Return_Null_Exception_ActorFullModel()
        {
            _selectCollectionActor = null;
            _mockUow.Setup(s => s.ActorRepository.GetAll())
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.GetAll_FullModel());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetActors_ByCountryId_GetGoodId_Return_Actors_ActorFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _countryDb.Id = id;
            _actorDb.Country = _countryDb;
            _selectCollectionActor.Add(_actorDb);
            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_By_Country_FullModel(id);

                Assert.That(result, Is.TypeOf<List<ActorFullModel>>());
            }
        }

        [Test]
        public void GetActors_ByCountryId_GetGoodId_Return_OneActor_ActorFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _selectCollectionActor.Add(_actorDb);
            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_By_Country_FullModel(id);

                Assert.That(result.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void GetActors_ByCountryId_GetGoodId_Return_TwoActors_ActorFullModel()
        {
              var id = Guid.NewGuid().ToString();
            _countryDb.Id = id;
            _actorDb.Country = _countryDb;
            _selectCollectionActor.Add(_actorDb);
            _selectCollectionActor.Add(new ActorDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ActorName",
                ImgLink = "ActorImg",
                Gender = "Gender",
                Video = new List<VideoDb>(),
                Rating = new List<ActorRatingDb>(),
                Country = _countryDb
            });
            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);
            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_By_Country_FullModel(id);

                Assert.That(result.Count, Is.EqualTo(2));
            }
        }
        [Test]
        public void GetActors_ByCountryId_AnyId_Return_Exception_ActorFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _countryDb.Id = id;
            _actorDb.Country = _countryDb;
            _selectCollectionActor.Add(_actorDb);
            _selectCollectionActor.Add(new ActorDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ActorName",
                ImgLink = "ActorImg",
                Gender = "Gender",
                Video = new List<VideoDb>(),
                Rating = new List<ActorRatingDb>(),
                Country = _countryDb
            });

            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);
            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.GetAll_By_Country_FullModel(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }

        }

        [Test]
        public void GetActors_ByCountryId_GetNullId_Return_Exception_ActorFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _countryDb.Id = id;
            _actorDb.Country = _countryDb;
            _selectCollectionActor.Add(_actorDb);
            _selectCollectionActor.Add(new ActorDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ActorName",
                ImgLink = "ActorImg",
                Gender = "Gender",
                Video = new List<VideoDb>(),
                Rating = new List<ActorRatingDb>(),
                Country = _countryDb
            });

            _mockUow.Setup(s => s.ActorRepository.Find(It.IsAny<Predicate<ActorDb>>()))
                .Returns(_selectCollectionActor);
            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.GetAll_By_Country_FullModel(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetAllActors_Return_Actors_ActorSmallModel()
        {
            _selectCollectionActor.Add(new ActorDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ActorName",
                ImgLink = "ActorImg",
                Gender = "Gender",
                Video = new List<VideoDb>(),
                Rating = new List<ActorRatingDb>(),
                Country = new CountryDb()

            });
            _mockUow.Setup(s => s.ActorRepository.GetAll())
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_SmallModel();

                Assert.That(result, Is.TypeOf<List<ActorSmallModel>>());
            }
        }

        [Test]
        public void GetAllActors_Return_OneActor_ActorSmallModel()
        {
            _selectCollectionActor.Add(new ActorDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ActorName",
                ImgLink = "ActorImg",
                Gender = "Gender",
                Video = new List<VideoDb>(),
                Rating = new List<ActorRatingDb>(),
                Country = new CountryDb()

            });
            _mockUow.Setup(s => s.ActorRepository.GetAll())
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_SmallModel();

                Assert.That(result.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void GetAllActors_Return_TwoActors_ActorSmallModel()
        {
            _selectCollectionActor.Add(new ActorDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ActorName",
                ImgLink = "ActorImg",
                Gender = "Gender",
                Video = new List<VideoDb>(),
                Rating = new List<ActorRatingDb>(),
                Country = new CountryDb()

            });
            _selectCollectionActor.Add(_actorDb);
            _mockUow.Setup(s => s.ActorRepository.GetAll())
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll_SmallModel();

                Assert.That(result.Count, Is.EqualTo(2));
            }
        }

        [Test]
        public void GetAllActors_Return_Null_Exception_ActorSmallModel()
        {
            _selectCollectionActor = null;
            _mockUow.Setup(s => s.ActorRepository.GetAll())
                .Returns(_selectCollectionActor);

            using (var service = new ActorService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.GetAll_SmallModel());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }
    }
}