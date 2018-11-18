using System;
using System.Collections.Generic;
using AutoMapper;
using Legendary.Business.Infrastructure.Mapping;
using Legendary.Business.Models;
using Legendary.Business.Services;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Rating;
using Legendary.Data.Models.Video;
using Moq;
using NUnit.Framework;

namespace Legendary.Business.Tests.Tests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private Mapper _mapper;
        private MapperConfiguration _configuration;
        private Mock<IUnitOfWork> _mockUow;

        private CategoryDb _categoryDb;
        private Category _category;
        private ICollection<CategoryDb> _selectCollectionCategories;


        [SetUp]
        public void SetUpMethod()
        {
            _categoryDb = new CategoryDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "CategoryName",
                ImgLink = "ReferenceImg",
                Video = new List<VideoDb>(),
                Rating = new List<CategoryRatingDb>()
            };
            _category = new Category
            {
                Id = Guid.NewGuid().ToString(),
                Name = "CategoryName",
                ImgLink = "ReferenceImg",
                Rating = 50
            };
            _selectCollectionCategories = new List<CategoryDb>();
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
        }

        [Test]
        public void AddCategory_CellMethod()
        {
            _mockUow.Setup(s => s.CategoryRepository.Find(It.IsAny<Predicate<CategoryDb>>()))
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                service.Create(_category);

                _mockUow.Verify(v => v.CategoryRepository.Create(It.IsAny<CategoryDb>()), Times.Once);
            }
        }

        [Test]
        public void AddCategory_Get_GoodArgument_Return_Exception()
        {
            _selectCollectionCategories.Add(_categoryDb);
            _mockUow.Setup(s => s.CategoryRepository.Find(It.IsAny<Predicate<CategoryDb>>()))
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Create(_category));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void AddCategory_Get_Null_Return_Exception()
        {
            _mockUow.Setup(s => s.CategoryRepository.Find(It.IsAny<Predicate<CategoryDb>>()))
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Create(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void AddCategory_NotAdmin_Return_Exception()
        {

        }

        [Test]
        public void DeleteCategory_CellMethod()
        {
            _selectCollectionCategories.Add(_categoryDb);
            _mockUow.Setup(s => s.CategoryRepository.Find(It.IsAny<Predicate<CategoryDb>>()))
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                service.Delete(_categoryDb.Id);

                _mockUow.Verify(v => v.CategoryRepository.Delete(_categoryDb.Id), Times.Once);
            }
        }

        [Test]
        public void DeleteCategory_Get_GoodArgument_Return_Exception()
        {
            _mockUow.Setup(s => s.CategoryRepository.Find(It.IsAny<Predicate<CategoryDb>>()))
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Delete(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void DeleteCategory_Get_Null_Return_Exception()
        {
            _mockUow.Setup(s => s.CategoryRepository.Find(It.IsAny<Predicate<CategoryDb>>()))
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Delete(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void DeleteCategory_NotAdmmin_Return_Exception()
        {

        }

        [Test]
        public void UpdateCategory_CellMethod()
        {
            _selectCollectionCategories.Add(_categoryDb);
            _mockUow.Setup(s => s.CategoryRepository.Find(It.IsAny<Predicate<CategoryDb>>()))
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                service.Update(_category.Id, _category);

                _mockUow.Verify(v => v.CategoryRepository.Update(It.IsAny<CategoryDb>()), Times.Once);
            }
        }

        [Test]
        public void UpdateCategory_GoodArguments_Return_Exception()
        {
            _mockUow.Setup(s => s.CategoryRepository.Find(It.IsAny<Predicate<CategoryDb>>()))
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Update(It.IsAny<string>(), _category));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void UpdateCategory_BadArgument_Id_Return_Exception()
        {
            _mockUow.Setup(s => s.CategoryRepository.Find(It.IsAny<Predicate<CategoryDb>>()))
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Update(null, _category));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void UpdateCategory_BadArgument_Model_Return_Exception()
        {
            _mockUow.Setup(s => s.CategoryRepository.Find(It.IsAny<Predicate<CategoryDb>>()))
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Update(It.IsAny<string>(), null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void UpdateCategory_NotAdmin_Return_Exception()
        {

        }

        [Test]
        public void GetCategory_ById_Get_GoodId_Return_Category()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.CategoryRepository.Get(id))
                .Returns(_categoryDb);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = service.Get(id);

                Assert.That(result, Is.TypeOf<Category>());
            }
        }

        [Test]
        public void GetCategory_ById_Get_GoodId_Return_Null_Exception()
        {
            var id = Guid.NewGuid().ToString();
            _categoryDb = null;
            _mockUow.Setup(s => s.CategoryRepository.Get(id))
                .Returns(_categoryDb);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Get(id));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetCategory_ById_Get_AnyId_Return_Null_Exception()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.CategoryRepository.Get(id))
                .Returns(_categoryDb);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Get(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetCategory_ById_Get_NullId_Return_Exception()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.CategoryRepository.Get(id))
                .Returns(_categoryDb);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.Get(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetAllCategories_Return_Categories()
        {
            _selectCollectionCategories.Add(_categoryDb);
            _selectCollectionCategories.Add(new CategoryDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "CategoryName",
                ImgLink = "ReferenceImg",
                Video = new List<VideoDb>(),
                Rating = new List<CategoryRatingDb>()
            });

            _mockUow.Setup(s => s.CategoryRepository.GetAll())
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll();

                Assert.That(result, Is.TypeOf<List<Category>>());
            }
        }

        [Test]
        public void GetAllCategories_Return_OneCategory()
        {
            _selectCollectionCategories.Add(new CategoryDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "CategoryName",
                ImgLink = "ReferenceImg",
                Video = new List<VideoDb>(),
                Rating = new List<CategoryRatingDb>()
            });

            _mockUow.Setup(s => s.CategoryRepository.GetAll())
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll();

                Assert.That(result.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void GetAllCategories_Return_TwoCategories()
        {
            _selectCollectionCategories.Add(_categoryDb);
            _selectCollectionCategories.Add(new CategoryDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "CategoryName",
                ImgLink = "ReferenceImg",
                Video = new List<VideoDb>(),
                Rating = new List<CategoryRatingDb>()
            });

            _mockUow.Setup(s => s.CategoryRepository.GetAll())
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = service.GetAll();

                Assert.That(result.Count, Is.EqualTo(2));
            }
        }

        [Test]
        public void GetAllCategory_Return_Null_Exception()
        {
            _selectCollectionCategories = null;
            _mockUow.Setup(s => s.CategoryRepository.GetAll())
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.GetAll());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetAllCategory_Return_Void_Exception()
        {
            _mockUow.Setup(s => s.CategoryRepository.GetAll())
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.GetAll());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetRandomCategory_Return_Category()
        {
            _selectCollectionCategories.Add(_categoryDb);
            _selectCollectionCategories.Add(new CategoryDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "CategoryName",
                ImgLink = "ReferenceImg",
                Video = new List<VideoDb>(),
                Rating = new List<CategoryRatingDb>()
            });

            _mockUow.Setup(s => s.CategoryRepository.GetAll())
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = service.GetRandom();

                Assert.That(result, Is.TypeOf<Category>());
            }
        }

        [Test]
        public void GetRandomCategory_Return_Null_Exception()
        {
            _selectCollectionCategories = null;
            _mockUow.Setup(s => s.CategoryRepository.GetAll())
                .Returns(_selectCollectionCategories);

            using (var service = new CategoryService(_mapper, _mockUow.Object))
            {
                var result = Assert.Throws<NullReferenceException>(() => service.GetRandom());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }
    }
}
