using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Legendary.Business.Models;
using Legendary.Business.Models.Video;
using Legendary.Business.Services;
using Legendary.Data.Interfaces;
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



        [SetUp]
        public void SetUpMethod()
        {
            _selectCollectionVideo = new List<VideoDb>();
            _videoDb = new VideoDb
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow
            };

            _videoFullModel = new VideoFullModel
            {
                Id = Guid.NewGuid().ToString(),
                Name = "VideoName",
                AvgRating = 50,
                ImgLink = "ImageReference",
                GifLink = "GifReference",
                ReferenceOnVideo = "VideoReference",
                DateCreate = DateTime.UtcNow
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
                Name = "CategoryName"
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
                    .ForMember(q => q.AvgRating,
                        opt => opt.MapFrom(w =>
                            w.Rating.Count == 0 ? 50
                            : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) > 50 ? 100
                            : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) < -50 ? 0
                            : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) + 50))
                    .ReverseMap()
                    .ForMember(q => q.Rating, opt => opt.Ignore());
                cfg.CreateMap<VideoDb, VideoFullModel>()
                    .ForMember(q => q.Categories, opt => opt.MapFrom(w => w.Categories))
                    .ForMember(q => q.AvgRating,
                        opt => opt.MapFrom(w =>
                            w.Rating.Count == 0 ? 50
                            : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) > 50 ? 100
                            : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) < -50 ? 0
                            : (Math.Round(w.Rating.Average(e => e.Rating), 2) * 100) + 50))
                    .ReverseMap()
                    .ForMember(q => q.Rating, opt => opt.Ignore());
            });
            _mapper = new Mapper(_configuration);

            _mockUow = new Mock<IUnitOfWork>();
        }

        [Test]
        [Ignore("Ignor")]
        public void AddVideo_VideoFullModel()
        {
        }

        [Test]
        [Ignore("Ignor")]
        public void DeleteVideo_VideoFullModel()
        {
        }

        [Test]
        [Ignore("Ignor")]
        public void UpdateVideo_VideoFullModel()
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
        public void GetVideo_ById_Get_NullId_Return_Null_VideoFullModel()
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
        public void GetVideo_ById_Get_AnyId_Return_Null_VideoFullModel()
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
        public void GetVideo_ById_Get_GoodId_Return_Null_VideoFullModel()
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
        public void GetAllVideo_Return_Null_VideoFullModel()
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
        public void GetVideo_ById_Get_NullId_Return_Null_VedeoListModel()
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
        public void GetVideo_ById_Get_AnyId_Return_Null_VedeoListModel()
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
        public void GetVideo_ById_Get_GoodId_Return_Null_VedeoListModel()
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
        public void GetAllVideo_Returns_Null_VideoListModel()
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
        public void GetRandomVideo_Returns_Null_VideoListModel()
        {
            _selectCollectionVideo = null;

            _mockUow.Setup(s => s.VideoRepository.GetAll())
                .Returns(_selectCollectionVideo);

            using (var videoListService = new VideoListService(_mockUow.Object, _mapper))
            {
                var result = Assert.Throws<NullReferenceException>(() => videoListService.GetRandomVideoList());

                Assert.That(result, Is.TypeOf<NullReferenceException>());
            }
        }

        [Test]
        public void GetRandomVideo_Get_VoidList_Returns_Null_VideoListModel()
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
        public void GetVideo_ById_Get_NullId_Return_Null_VedeoItemModel()
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
        public void GetVideo_ById_Get_AnyId_Return_Null_VedeoItemModel()
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
        public void GetVideo_ById_Get_GoodId_Return_Null_VedeoItemModel()
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
