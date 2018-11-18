using System;
using System.Collections.Generic;
using AutoMapper;
using Legendary.Business.Infrastructure.Mapping;
using Legendary.Business.Models;
using Legendary.Business.Services;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Actor;
using Legendary.Data.Models.Country;
using Legendary.Data.Models.Studio;
using Moq;
using NUnit.Framework;

namespace Legendary.Business.Tests.Tests
{
    [TestFixture]
    public class CoutryServiceTests
    {
        private Mapper _mapper;
        private MapperConfiguration _configuration;
        private Mock<IUnitOfWork> _mockUow;

        private ICollection<CountryDb> _selectCollectionCountry;
        private CountryDb _countryDb;
        private Country _countryDto;



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

            _countryDto = new Country
            {
                Id = Guid.NewGuid().ToString(),
                CountryName = "Haiti"
            };

            _selectCollectionCountry = new List<CountryDb>();
        }

        [Test]
        public void AddCountry_CellMethod()
        {
            _mockUow.Setup(s => s.CountryRepository.Find(It.IsAny<Predicate<CountryDb>>()))
                .Returns(_selectCollectionCountry);
            using (var countryService = new CountryService(_mapper, _mockUow.Object))
            {
                countryService.Create(_countryDto);

                _mockUow.Verify(v => v.CountryRepository.Create(It.IsAny<CountryDb>()), Times.Once);
            }
        }

        [Test]
        public void AddCountry_Get_GoodArgument_Return_Exception()
        {
            _selectCollectionCountry.Add(_countryDb);
            _mockUow.Setup(s => s.CountryRepository.Find(It.IsAny<Predicate<CountryDb>>()))
                .Returns(_selectCollectionCountry);

            using (var countryService = new CountryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => countryService.Create(_countryDto));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void AddCountry_Get_Null_Return_Exception()
        {
            _selectCollectionCountry.Add(_countryDb);
            _mockUow.Setup(s => s.CountryRepository.Find(It.IsAny<Predicate<CountryDb>>()))
                .Returns(_selectCollectionCountry);

            using (var countryService = new CountryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => countryService.Create(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void AddCountry_NotAdmin_Return_Exception()
        {

        }

        [Test]
        public void DeleteCountry_CellMethod()
        {
            _selectCollectionCountry.Add(_countryDb);
            _mockUow.Setup(s => s.CountryRepository.Find(It.IsAny<Predicate<CountryDb>>()))
                .Returns(_selectCollectionCountry);

            using (var countryService = new CountryService(_mapper, _mockUow.Object))
            {
                countryService.Delete(_countryDb.Id);

                _mockUow.Verify(v => v.CountryRepository.Delete(It.IsAny<string>()), Times.Once);
            }

        }

        [Test]
        public void DeleteCountry_Get_GoodArgument_Return_Exception()
        {
            _mockUow.Setup(s => s.CountryRepository.Find(It.IsAny<Predicate<CountryDb>>()))
                .Returns(_selectCollectionCountry);

            using (var countryService = new CountryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => countryService.Delete(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void DeleteCountry_Get_Null_Return_Exception()
        {
            _mockUow.Setup(s => s.CountryRepository.Find(It.IsAny<Predicate<CountryDb>>()))
                .Returns(_selectCollectionCountry);

            using (var countryService = new CountryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => countryService.Delete(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void DeleteCountry_NotAdmmin_Return_Exception()
        {

        }

        [Test]
        public void UpdateCountry_CellMethod()
        {
            _selectCollectionCountry.Add(_countryDb);
            _mockUow.Setup(s => s.CountryRepository.Find(It.IsAny<Predicate<CountryDb>>()))
                .Returns(_selectCollectionCountry);
            using (var countryService = new CountryService(_mapper, _mockUow.Object))
            {
                countryService.Update(_countryDb.Id, _countryDto);

                _mockUow.Verify(v => v.CountryRepository.Update(It.IsAny<CountryDb>()), Times.Once);
            }
        }

        [Test]
        public void UpdateCountry_GoodArguments_Return_Exception()
        {
            _mockUow.Setup(s => s.CountryRepository.Find(It.IsAny<Predicate<CountryDb>>()))
                .Returns(_selectCollectionCountry);

            using (var countryService = new CountryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => countryService.Update(_countryDb.Id, _countryDto));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void UpdateCountry_BadArgument_Id_Return_Exception()
        {
            _mockUow.Setup(s => s.CountryRepository.Find(It.IsAny<Predicate<CountryDb>>()))
                .Returns(_selectCollectionCountry);

            using (var countryService = new CountryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => countryService.Update(null, _countryDto));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void UpdateCountry_BadArgument_Model_Return_Exception()
        {
            _mockUow.Setup(s => s.CountryRepository.Find(It.IsAny<Predicate<CountryDb>>()))
                .Returns(_selectCollectionCountry);

            using (var countryService = new CountryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => countryService.Update(_countryDb.Id, null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void UpdateCountry_NotAdmin_Return_Exception()
        {

        }

        [Test]
        public void GetCountry_ById_Get_GoodId_Return_Country()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.CountryRepository.Get(id))
                .Returns(_countryDb);

            using (var countryService = new CountryService(_mapper, _mockUow.Object))
            {
                var result = countryService.Get(id);

                Assert.That(result, Is.TypeOf<Country>());
            }
        }

        [Test]
        public void GetCountry_ById_Get_GoodId_Return_Null_Exception()
        {
            _countryDb = null;
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.CountryRepository.Get(id))
                .Returns(_countryDb);

            using (var countriService = new CountryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => countriService.Get(id));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetCountry_ById_Get_AnyId_Return_Null_Exception()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.CountryRepository.Get(id))
                .Returns(_countryDb);

            using (var countryService = new CountryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() =>  countryService.Get(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetCountry_ById_Get_NullId_Return_Exception()
        {
            _mockUow.Setup(s => s.CountryRepository.Get(It.IsAny<string>()))
                .Returns(_countryDb);

            using (var countryService = new CountryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => countryService.Get(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetAllCountry_Return_Country()
        {
            _selectCollectionCountry.Add(new CountryDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "AnyName",
                Studio = new List<StudioDb>(),
                Actors = new List<ActorDb>()
            });

            _mockUow.Setup(s => s.CountryRepository.GetAll())
                .Returns(_selectCollectionCountry);

            using (var service = new CountryService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll();

                Assert.That(result, Is.TypeOf<List<Country>>());
            }
        }

        [Test]
        public void GetAllCountry_Return_OneCountry()
        {
            _selectCollectionCountry.Add(new CountryDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "AnyName",
                Studio = new List<StudioDb>(),
                Actors = new List<ActorDb>()
            });

            _mockUow.Setup(s => s.CountryRepository.GetAll())
                .Returns(_selectCollectionCountry);

            using (var service = new CountryService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll();

                Assert.That(result.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void GetAllCountry_Return_TwoCountry()
        {
            _selectCollectionCountry.Add(_countryDb);
            _selectCollectionCountry.Add(new CountryDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "AnyName",
                Studio = new List<StudioDb>(),
                Actors = new List<ActorDb>()
            });

            _mockUow.Setup(s => s.CountryRepository.GetAll())
                .Returns(_selectCollectionCountry);

            using (var service = new CountryService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll();

                Assert.That(result.Count, Is.EqualTo(2));
            }
        }

        [Test]
        public void GetAllCountry_Return_Null_Exception()
        {
            _selectCollectionCountry = null;
            _mockUow.Setup(s => s.CountryRepository.GetAll())
                .Returns(_selectCollectionCountry);

            using (var service = new CountryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() =>  service.GetAll());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetAllCountry_Return_Void_Exception()
        {
            _mockUow.Setup(s => s.CountryRepository.GetAll())
                .Returns(_selectCollectionCountry);

            using (var service = new CountryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.GetAll());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }
    }
}