using System;
using System.Collections.Generic;
using AutoMapper;
using Legendary.Business.Models;
using Legendary.Business.Models.Video;
using Legendary.Business.Services;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Actor;
using Legendary.Data.Models.Rating;
using Legendary.Data.Models.Video;
using NUnit.Framework;
using Moq;
using Legendary.Business.Infrastructure.Mapping;
using Legendary.Business.Models.Actor;
using Legendary.Business.Models.Studio;
using Legendary.Data.Models.Country;
using Legendary.Data.Models.Studio;


namespace Legendary.Business.Tests.Tests
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mapper _mapper;
        private MapperConfiguration _configuration;
        private Mock<IUnitOfWork> _mockUow;

        private ICollection<VideoDb> _selectCollectionVideo;
        private VideoDb _videoDb;
        private VideoFullModel _videoFullModel;

        private CategoryDb _categoryDb;

        private ActorDb _actorDb;

        private StudioDb _studio;



        [SetUp]
        public void SetUpMethod()
        {
            _selectCollectionVideo = new List<VideoDb>();
            
            _studio = new StudioDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ActorName",
                ImgLink = "ImageReference",
                Video = new List<VideoDb>(),
                Rating = new List<StudioRatingDb>(),
                Cauntry = new CountryDb()
            };

            _actorDb = new ActorDb
            {
                Id =  Guid.NewGuid().ToString(),
                Name = "ActorName",
                ImgLink = "ImageReference",
                Gender = "Man",
                Video = new List<VideoDb>()
            };

            _videoDb = new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow,
                Actor = new List<ActorDb>(),
                Categories = new List<CategoryDb>(),
                Comments = new List<CommentDb>(),
                Rating = new List<VideoRatingDb>(),
                Studio = new StudioDb()
            };

            _videoFullModel = new VideoFullModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                AvgRating = 50,
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow,
                Categories = new List<Category>(),
                Actors = new List<ActorSmallModel>(),
                Studio = new StudioSmallModel()
            };

            _categoryDb = new CategoryDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "CategoryName",
                Video = new List<VideoDb>()
            };

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
        public void AddVideo_CallMethod()
        {
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                videoService.Create(_videoFullModel);

                _mockUow.Verify(v => v.VideoRepository.Create(It.IsAny<VideoDb>()), Times.Once());
            }
        }

        [Test]
        public void AddVideo_BadArgument_Return_Exception()
        {
            _videoFullModel.Id = _videoDb.Id;
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Create(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void AddVideo_NotAdmin_Return_Exception()
        {
        }

        [Test]
        public void DeleteVideo_CallMethod()
        {
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                videoService.Delete(_videoDb.Id);

                _mockUow.Verify(v => v.VideoRepository.Delete(It.IsAny<string>()), Times.Once());

            }
        }

        [Test]
        public void DeleteVideo_BadArgument_Return_Exception()
        {
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Delete(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void DeleteVideo_NotAdmin_Return_Exception()
        {
        }

        [Test]
        public void UpdateVideo_CallMethod()
        {
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                videoService.Update(_videoDb.Id, _videoFullModel);

                _mockUow.Verify(v => v.VideoRepository.Update(It.IsAny<VideoDb>()), Times.Once());
            }
        }

        [Test]
        public void UpdateVideo_BadArgument_Id_Return_Exception()
        {
            _videoFullModel.Id = _videoDb.Id;
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Update(null, _videoFullModel));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void UpdateVideo_BadArgument_Model_Return_Exception()
        {
            _videoFullModel.Id = _videoDb.Id;
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Update(It.IsAny<string>(),null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void UpdateVideo_BadArguments_Return_Exception()
        {
            _videoFullModel.Id = _videoDb.Id;
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Update(null, null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void UpdateVideo_NotAdmin()
        {
        }

        [Test]
        public void GetVideo_ById_Get_GoodId_Return_Video_VideoFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.Get_FullModel(id);

                Assert.That(result, Is.TypeOf(typeof(VideoFullModel)));
            }
        }

        [Test]
        public void GetVideo_ById_Get_NullId_Return_NullReferenceException_VideoFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_FullModel(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_AnyId_Return_NullReferenceException_VideoFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_FullModel(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_GoodId_Return_NullReferenceException_VideoFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _videoDb = null;
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_FullModel(id));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ByActor_Get_GoodActorId_Return_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _actorDb.Id = id;
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow,
                Actor = new List<ActorDb>
                {
                    _actorDb,
                    new ActorDb
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "ActorName",
                        ImgLink = "ImageReference",
                        Gender = "Man",
                        Video = new List<VideoDb>()
                    }
                },
                Categories = new List<CategoryDb>(),
                Comments = new List<CommentDb>(),
                Rating = new List<VideoRatingDb>(),
                Studio = new StudioDb()
            });

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.Get_ByActor_SmallModel(id);

                Assert.That(result, Is.TypeOf<List<VideoSmallModel>>());
            }
        }

        [Test]
        public void GetVideo_ByActor_Get_GoodActorId_Return_OneVideo_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _actorDb.Id = id;
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow,
                Actor = new List<ActorDb>
                {
                    _actorDb,
                    new ActorDb
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "ActorName",
                        ImgLink = "ImageReference",
                        Gender = "Man",
                        Video = new List<VideoDb>()
                    }
                },
                Categories = new List<CategoryDb>(),
                Comments = new List<CommentDb>(),
                Rating = new List<VideoRatingDb>(),
                Studio = new StudioDb()
            });

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.Get_ByActor_SmallModel(id);

                Assert.That(result.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void GetVideo_ByActor_Get_GoodActorId_Return_TwoVideo_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _actorDb.Id = id;
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow,
                Actor = new List<ActorDb>
                {
                    _actorDb,
                    new ActorDb
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "ActorName",
                        ImgLink = "ImageReference",
                        Gender = "Man",
                        Video = new List<VideoDb>()
                    }
                },
                Categories = new List<CategoryDb>(),
                Comments = new List<CommentDb>(),
                Rating = new List<VideoRatingDb>(),
                Studio = new StudioDb()
            });
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow,
                Actor = new List<ActorDb>
                {
                    new ActorDb
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "ActorName",
                        ImgLink = "ImageReference",
                        Gender = "Man",
                        Video = new List<VideoDb>()
                    }
                },
                Categories = new List<CategoryDb>(),
                Comments = new List<CommentDb>(),
                Rating = new List<VideoRatingDb>(),
                Studio = new StudioDb()
            });

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.Get_ByActor_SmallModel(id);

                Assert.That(result.Count, Is.EqualTo(2));
            }
        }

        [Test]
        [Ignore("Надо понять как ловить экс")]
        public void GetVideo_ByActor_Get_GoodActorId_Return_NullReferenceException_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _selectCollectionVideo = null;

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_ByActor_SmallModel(id));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ByActor_Get_GoodActorId_Return_ArgumentNullException_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _selectCollectionVideo = null;

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<ArgumentNullException>(() => videoService.Get_ByActor_SmallModel(id));

                Assert.That(result, Is.TypeOf<ArgumentNullException>());
            }
        }

        [Test]
        public void GetVideo_ByActor_Get_AnyActorId_Return_NullReferenceException_VideoSmallModel()
        {

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_ByActor_SmallModel(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ByActor_Get_NullActorId_Return_NullReferenceException_VideoSmallModel()
        {

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);


            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_ByActor_SmallModel(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ByCategory_Get_GoodCategoryId_Return_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _categoryDb.Id = id;
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow,
                Actor = new List<ActorDb>(),
                Categories = new List<CategoryDb>
                {
                    _categoryDb,
                    new CategoryDb
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "CategoryName",
                        Video = new List<VideoDb>()
                    }

                },
                Comments = new List<CommentDb>(),
                Rating = new List<VideoRatingDb>(),
                Studio = _studio
            });

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.Get_ByCategory_SmallModel(id);

                Assert.That(result, Is.TypeOf<List<VideoSmallModel>>());
            }
        }

        [Test]
        public void GetVideo_ByCategory_Get_GoodCategoryId_Return_OneVideo_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _categoryDb.Id = id;
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow,
                Actor = new List<ActorDb>(),
                Categories = new List<CategoryDb>
                {
                    _categoryDb,
                    new CategoryDb
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "CategoryName",
                        Video = new List<VideoDb>()
                    }

                },
                Comments = new List<CommentDb>(),
                Rating = new List<VideoRatingDb>(),
                Studio = _studio
            });


            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.Get_ByCategory_SmallModel(id);

                Assert.That(result.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void GetVideo_ByCategory_Get_GoodCategoryId_Return_TwoVideo_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _categoryDb.Id = id;
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow,
                Actor = new List<ActorDb>(),
                Categories = new List<CategoryDb>
                {
                    _categoryDb,
                    new CategoryDb
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "CategoryName",
                        Video = new List<VideoDb>()
                    }

                },
                Comments = new List<CommentDb>(),
                Rating = new List<VideoRatingDb>(),
                Studio = _studio
            });
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow,
                Actor = new List<ActorDb>(),
                Categories = new List<CategoryDb>
                {
                    new CategoryDb
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "CategoryName",
                        Video = new List<VideoDb>()
                    }

                },
                Comments = new List<CommentDb>(),
                Rating = new List<VideoRatingDb>(),
                Studio = _studio
            });

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.Get_ByCategory_SmallModel(id);

                Assert.That(result.Count, Is.EqualTo(2));
            }
        }

        [Test]
        public void GetVideo_ByCategory_Get_GoodCategoryId_ArgumentNullException_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _selectCollectionVideo = null;

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<ArgumentNullException>(() => videoService.Get_ByCategory_SmallModel(id));

                Assert.That(result, Is.TypeOf<ArgumentNullException>());
            }
        }

        [Test]
        public void GetVideo_ByCategory_Get_AnyCategoryId_Return_NullReferenceException_VideoSmallModel()
        {
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result =
                    Assert.Throws<NullReferenceException>(() =>
                        videoService.Get_ByCategory_SmallModel(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ByCategory_Get_NullCategoryId_Return_NullReferenceException_VideoSmallModel()
        {
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_ByCategory_SmallModel(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ByStudio_Get_GoodStudioId_Return_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();

            _videoDb.Studio = _studio;
            _videoDb.Studio.Id = id;
            _selectCollectionVideo.Add(_videoDb);

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.Get_ByStudio_SmallModel(id);

                Assert.That(result, Is.TypeOf<List<VideoSmallModel>>());
            }
        }

        [Test]
        public void GetVideo_ByStudio_Get_GoodStudioId_Return_OneVideo_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();

            _videoDb.Studio = _studio;
            _videoDb.Studio.Id = id;
            _selectCollectionVideo.Add(_videoDb);

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.Get_ByStudio_SmallModel(id);

                Assert.That(result.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void GetVideo_ByStudio_Get_GoodStudioId_Return_TwoVideo_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _studio.Id = id;
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow,
                Actor = new List<ActorDb>(),
                Categories = new List<CategoryDb>(),
                Comments = new List<CommentDb>(),
                Rating = new List<VideoRatingDb>(),
                Studio = new StudioDb
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "ActorName",
                    ImgLink = "ImageReference",
                    Video = new List<VideoDb>(),
                    Rating = new List<StudioRatingDb>(),
                    Cauntry = new CountryDb()
                }
            });
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow,
                Actor = new List<ActorDb>(),
                Categories = new List<CategoryDb>(),
                Comments = new List<CommentDb>(),
                Rating = new List<VideoRatingDb>(),
                Studio = _studio
            });

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.Get_ByStudio_SmallModel(id);

                Assert.That(result.Count, Is.EqualTo(2));
            }
        }

        [Test]
        public void GetVideo_ByStudio_Get_GoodStudioId_ArgumentNullException_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _selectCollectionVideo = null;

            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<ArgumentNullException>(() => videoService.Get_ByStudio_SmallModel(id));

                Assert.That(result, Is.TypeOf<ArgumentNullException>());
            }
        }

        [Test]
        public void GetVideo_ByStudio_Get_AnyStudioId_Return_NullReferenceException_VideoSmallModel()
        {
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result =
                    Assert.Throws<NullReferenceException>(() =>
                        videoService.Get_ByStudio_SmallModel(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ByStudio_Get_NullStudioId_Return_NullReferenceException_VideoSmallModel()
        {
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_ByStudio_SmallModel(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetAllVideo_Return_AllVideo_VideoFullModel()
        {
            _selectCollectionVideo.Add(_videoDb);
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName1",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow
            });

            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.GetAll_FullModel();

                Assert.That(result, Is.TypeOf<List<VideoFullModel>>());
            }
        }

        [Test]
        public void GetAllVideo_Return_NullReferenceException_VideoFullModel()
        {
            _selectCollectionVideo = null;
            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.GetAll_FullModel());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_GoodId_Return_Video_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.Get_SmallModel(id);

                Assert.That(result, Is.TypeOf<VideoSmallModel>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_NullId_Return_NullReferenceException_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_SmallModel(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_AnyId_Return_NullReferenceException_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_SmallModel(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_GoodId_Return_NullReferenceException_VideoSmallModel()
        {
            var id = Guid.NewGuid().ToString();
            _videoDb = null;
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_SmallModel(id));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetAllVideo_Returns_Video_VideoSmallModel()
        {
            _selectCollectionVideo.Add(_videoDb);
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName1",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow
            });

            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.GetAll_SmallModel();

                Assert.That(result, Is.TypeOf<List<VideoSmallModel>>());
            }
        }

        [Test]
        public void GetAllVideo_Returns_NullReferenceException_VideoSmallModel()
        {
            _selectCollectionVideo = null;

            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.GetAll_SmallModel());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetRandomVideo_Returns_Video_VideoSmallModel()
        {
            _selectCollectionVideo.Add(_videoDb);
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName1",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow
            });

            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.GetRandom_SmallModel();

                Assert.That(result, Is.TypeOf<VideoSmallModel>());
            }
        }

        [Test]
        public void GetRandomVideo_Returns_ArgumentNullException_VideoSmallModel()
        {
            _selectCollectionVideo = null;

            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<ArgumentNullException>(() => videoService.GetRandom_SmallModel());

                Assert.That(result, Is.TypeOf<ArgumentNullException>());
            }
        }

        [Test]
        public void GetRandomVideo_Get_VoidList_Returns_NullReferenceException_VideoSmallModel()
        {
            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.GetRandom_SmallModel());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_GoodId_Return_Video_VedeoItemModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.Get_ItemModel(id);

                Assert.That(result, Is.TypeOf<VideoItemModel>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_NullId_Return_NullReferenceException_VedeoItemModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_ItemModel(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_AnyId_Return_NullReferenceException_VedeoItemModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_ItemModel(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_GoodId_Return_NullReferenceException_VedeoItemModel()
        {
            var id = Guid.NewGuid().ToString();
            _videoDb = null;
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.Get_ItemModel(id));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetRandomVideo_Returns_Video_VideoItemModel()
        {
            _selectCollectionVideo.Add(_videoDb);
            _selectCollectionVideo.Add(new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName1",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow
            });

            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoService.GetRandom_ItemModel();

                Assert.That(result, Is.TypeOf<VideoItemModel>());
            }
        }

        [Test]
        public void GetRandomVideo_Returns_ArgumentNullException_VideoItemModel()
        {
            _selectCollectionVideo = null;

            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<ArgumentNullException>(() => videoService.GetRandom_ItemModel());

                Assert.That(result, Is.TypeOf<ArgumentNullException>());
            }
        }

        [Test]
        public void GetRandomVideo_Get_VoidList_Returns_NullReferenceException_VideoItemModel()
        {
            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoService.GetRandom_ItemModel());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }
    }
}