using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Legendary.Business.Models;
using Legendary.Business.Models.Video;
using Legendary.Business.Services.Video;
using Legendary.Data.Interfaces;
using Legendary.Data.Models.Actor;
using Legendary.Data.Models.Video;
using NUnit.Framework;
using Moq;

namespace Legendary.Business.Tests
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
        private VideoItemDto _videoItem;
        private VideoListDto _videoList;

        private CategoryDb _categoryDb;
        private CategoryDto _categoryDto;

        private RatingDb _ratingDb;

        private ActorDb _actorDb;



        [SetUp]
        public void SetUpMethod()
        {
            _selectCollectionVideo = new List<VideoDb>();

            _actorDb = new ActorDb
            {
                Id =  Guid.NewGuid().ToString(),
                Name = "ActorName",
                ImgLink = "ImageReference",
                Gender = Gender.Man,
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
                Rating = new List<RatingDb>()
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
                Categories = new List<CategoryDto>(),
                Actors = new List<ActorDto>()
            };

            _videoList = new VideoListDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                ImgLink = "ImageReference",
                GifLink = "GifReference"
            };

            _videoItem = new VideoItemDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                AvgRating = 50,
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow
            };

            _categoryDb = new CategoryDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "CategoryName",
                Video = new List<VideoDb>()
            };

            _categoryDto = new CategoryDto
            {
                Id = Guid.NewGuid().ToString(),
                Name = "CategoryName"
            };

            _ratingDb = new RatingDb
            {
                Id = Guid.NewGuid().ToString(),
                Rating = 1
            };


            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VideoDb, VideoListDto>();

                cfg.CreateMap<VideoDb, VideoItemDto>()
                    .ForMember(q => q.Categories, opt => opt.MapFrom(w => w.Categories))
                    .ForMember(q => q.Actors, opt => opt.MapFrom(w => w.Actor))
                    .ForMember(q => q.AvgRating,
                        opt => opt.MapFrom(w =>
                            w.Rating.Count == 0 ? 50
                            : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) > 50 ? 100
                            : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) < -50 ? 0
                            : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) + 50))
                    .ReverseMap()
                    .ForMember(q => q.Rating, opt => opt.Ignore())
                    .ForMember(q => q.Actor, opt => opt.MapFrom(w => w.Actors));

                cfg.CreateMap<VideoDb, VideoFullModel>()
                    .ForMember(q => q.Actors, opt => opt.MapFrom(w => w.Actor))
                    .ForMember(q => q.Categories, opt => opt.MapFrom(w => w.Categories))
                    .ForMember(q => q.AvgRating,
                        opt => opt.MapFrom(w =>
                            w.Rating.Count == 0 ? 50
                            : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) > 50 ? 100
                            : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) < -50 ? 0
                            : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) + 50))
                    .ReverseMap()
                    .ForMember(q => q.Actor, opt => opt.MapFrom(w => w.Actors))
                    .ForMember(q => q.Categories, opt => opt.MapFrom(w => w.Categories))
                    .ForMember(q => q.Rating, opt => opt.Ignore())
                    .ForMember(q => q.Comments, opt => opt.Ignore())
                    .ForMember(q => q.DateCreate, opt => opt.Ignore());
            });
            _mapper = new Mapper(_configuration);

            _mockUow = new Mock<IUnitOfWork>();
        }

        [Test]
        public void AddVideo_CallMethod()
        {
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                videoFullService.CreateVideo(_videoFullModel);

                _mockUow.Verify(v => v.VideoRepository.Create(It.IsAny<VideoDb>()), Times.Once());
            }
        }

        [Test]
        public void AddVideo_BadArgument()
        {
            _videoFullModel.Id = _videoDb.Id;
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoFullService.CreateVideo(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void AddVideo_NotAdmin()
        {
        }

        [Test]
        public void DeleteVideo_CallMethod()
        {
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                videoFullService.DeleteVideo(_videoDb.Id);

                _mockUow.Verify(v => v.VideoRepository.Delete(It.IsAny<string>()), Times.Once());

            }
        }

        [Test]
        public void DeleteVideo_BadArgument()
        {
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoFullService.DeleteVideo(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Ignore("Watch in a method")]
        public void DeleteVideo_NotAdmin()
        {
        }

        [Test]
        public void UpdateVideo_CallMethod()
        {
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                videoFullService.UpdateVideo(_videoDb.Id, _videoFullModel);

                _mockUow.Verify(v => v.VideoRepository.Update(It.IsAny<VideoDb>()), Times.Once());
            }
        }

        [Test]
        public void UpdateVideo_BadArgument_Id()
        {
            _videoFullModel.Id = _videoDb.Id;
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoFullService.UpdateVideo(null, _videoFullModel));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void UpdateVideo_BadArgument_Model()
        {
            _videoFullModel.Id = _videoDb.Id;
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoFullService.UpdateVideo(It.IsAny<string>(),null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void UpdateVideo_BadArguments()
        {
            _videoFullModel.Id = _videoDb.Id;
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoFullService.UpdateVideo(null, null));

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

            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoFullService.GetVideo(id);

                Assert.That(result, Is.TypeOf(typeof(VideoFullModel)));
            }
        }

        [Test]
        public void GetVideo_ById_Get_NullId_Return_NullReferenceException_VideoFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoFullService.GetVideo(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_AnyId_Return_NullReferenceException_VideoFullModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoFullService.GetVideo(It.IsAny<string>()));

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

            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoFullService.GetVideo(id));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ByActor_Get_GoodActorId_Return_Video_VideoListModel()
        {
            var id = Guid.NewGuid().ToString();
            _videoDb.Actor.Add(_actorDb);
            _actorDb.Id = id;
            _videoDb.Actor.Add(_actorDb);
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = videoListService.GetVideoByActor(id);

                Assert.That(result.Count, Is.EqualTo(1));
            }
        }

        [Test]
        [Ignore("Надо понять как ловить экс")]
        public void GetVideo_ByActor_Get_GoodActorId_Return_NullReferenceException_VideoListModel()
        {
            var id = Guid.NewGuid().ToString();
            _selectCollectionVideo = null;
            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoListService.GetVideoByActor(id));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ByActor_Get_GoodActorId_Return_ArgumentNullException_VideoListModel()
        {
            var id = Guid.NewGuid().ToString();
            _selectCollectionVideo = null;
            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<ArgumentNullException>(() => videoListService.GetVideoByActor(id));

                Assert.That(result, Is.TypeOf<ArgumentNullException>());
            }
        }

        [Test]
        public void GetVideo_ByActor_Get_AnyActorId_Return_NullReferenceException_VideoListModel()
        {
            var id = Guid.NewGuid().ToString();
            _videoDb.Actor.Add(_actorDb);
            _actorDb.Id = id;
            _videoDb.Actor.Add(_actorDb);
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoListService.GetVideoByActor(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ByActor_Get_NullActorId_Return_NullReferenceException_VideoListModel()
        {
            var id = Guid.NewGuid().ToString();
            _videoDb.Actor.Add(_actorDb);
            _actorDb.Id = id;
            _videoDb.Actor.Add(_actorDb);
            _selectCollectionVideo.Add(_videoDb);
            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoListService.GetVideoByActor(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ByCategory_Get_GoodCategoryId_Return_Video_VedeoListModel()
        {
            var id = Guid.NewGuid().ToString();
            _videoDb.Categories.Add(_categoryDb);
            _categoryDb.Id = id;
            _videoDb.Categories.Add(_categoryDb);
            _selectCollectionVideo.Add(_videoDb);

            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            /*
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            */

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = videoListService.GetVideoByCategory(id);

                Assert.That(result.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void GetVideo_ByCategory_Get_GoodCategoryId_ArgumentNullException_VedeoListModel()
        {
            var id = Guid.NewGuid().ToString();
            _selectCollectionVideo = null;

            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);
            /*
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            */

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<ArgumentNullException>(() => videoListService.GetVideoByCategory(id));

                Assert.That(result, Is.TypeOf<ArgumentNullException>());
            }
        }

        [Test]
        public void GetVideo_ByCategory_Get_AnyCategoryId_Return_NullReferenceException_VedeoListModel()
        {
            _selectCollectionVideo.Add(_videoDb);

            _mockUow.Setup(s => s.VideoRepository.GetAll()).Returns(_selectCollectionVideo);

            /*
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            */
            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result =
                    Assert.Throws<NullReferenceException>(() =>
                        videoListService.GetVideoByCategory(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ByCategory_Get_NullCategoryId_Return_NullReferenceException_VedeoListModel()
        {
            _selectCollectionVideo.Add(_videoDb);

            _mockUow.Setup(s => s.VideoRepository.GetAll()).Returns(_selectCollectionVideo);

            /*
            _mockUow.Setup(s => s.VideoRepository.Find(It.IsAny<Predicate<VideoDb>>()))
                .Returns(_selectCollectionVideo);
            */

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoListService.GetVideoByCategory(null));

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

            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = videoFullService.GetListVideo();

                Assert.That(result, Is.TypeOf(typeof(List<VideoFullModel>)));
            }
        }

        [Test]
        public void GetAllVideo_Return_NullReferenceException_VideoFullModel()
        {
            _selectCollectionVideo = null;
            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoFullService = new VideoService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoFullService.GetListVideo());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_GoodId_Return_Video_VideoListModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = videoListService.GetVideoList(id);

                Assert.That(result, Is.TypeOf(typeof(VideoListDto)));
            }
        }

        [Test]
        public void GetVideo_ById_Get_NullId_Return_NullReferenceException_VedeoListModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoListService.GetVideoList(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_AnyId_Return_NullReferenceException_VedeoListModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoListService.GetVideoList(It.IsAny<string>()));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_GoodId_Return_NullReferenceException_VedeoListModel()
        {
            var id = Guid.NewGuid().ToString();
            _videoDb = null;
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoListService.GetVideoList(id));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetAllVideo_Returns_Video_VideoListModel()
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

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = videoListService.GetAllVideoList();

                Assert.That(result, Is.TypeOf(typeof(List<VideoListDto>)));
            }
        }

        [Test]
        public void GetAllVideo_Returns_NullReferenceException_VideoListModel()
        {
            _selectCollectionVideo = null;

            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoListService.GetAllVideoList());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        [Repeat(500)]
        public void GetRandomVideo_Returns_Video_VideoListModel()
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

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = videoListService.GetRandomVideoList();

                Assert.That(result, Is.TypeOf(typeof(VideoListDto)));
            }
        }

        [Test]
        public void GetRandomVideo_Returns_ArgumentNullException_VideoListModel()
        {
            _selectCollectionVideo = null;

            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<ArgumentNullException>(() => videoListService.GetRandomVideoList());

                Assert.That(result, Is.TypeOf<ArgumentNullException>());
            }
        }

        [Test]
        public void GetRandomVideo_Get_VoidList_Returns_NullReferenceException_VideoListModel()
        {
            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoListService.GetRandomVideoList());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_GoodId_Return_Video_VedeoItemModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoItemService = new VideoItemService(_mockUow.Object, _mapper))
            {
                var result = videoItemService.GetVideoItem(id);

                Assert.That(result, Is.TypeOf(typeof(VideoItemDto)));
            }
        }

        [Test]
        public void GetVideo_ById_Get_NullId_Return_NullReferenceException_VedeoItemModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoItemService = new VideoItemService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoItemService.GetVideoItem(null));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetVideo_ById_Get_AnyId_Return_NullReferenceException_VedeoItemModel()
        {
            var id = Guid.NewGuid().ToString();
            _mockUow.Setup(s => s.VideoRepository.Get(id))
                .Returns(_videoDb);

            using (var videoItemService = new VideoItemService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoItemService.GetVideoItem(It.IsAny<string>()));

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

            using (var videoItemService = new VideoItemService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoItemService.GetVideoItem(id));

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }
    }
}