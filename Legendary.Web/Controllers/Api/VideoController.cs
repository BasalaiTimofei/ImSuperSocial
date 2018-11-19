using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Legendary.Business.Interfaces;
using Legendary.Business.Models.Video;

namespace Legendary.Web.Controllers.Api
{
    [RoutePrefix("api/video")]
    public class VideoController : ApiController
    {
        private readonly IVideoService _service;
        public VideoController(IVideoService service)
        {
            _service = service;
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetAll Video result", typeof(IEnumerable<VideoSmallModel>))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Video were not found in database")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpGet, Route("smallModel")]
        public IHttpActionResult GetAll_SmallModel()
        {
            try
            {
                return Ok(_service.GetAll_SmallModel());
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetById video result", typeof(VideoSmallModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
         */
        [HttpGet, Route("smallModel/{videoId:string}")]
        public IHttpActionResult Get_By_Id_SmallModel([FromUri] string videoId)
        {
            try
            {
                return Ok(_service.Get_SmallModel(videoId));
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetByActorId video result", typeof(VideoSmallModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpGet, Route("smallModel/actor/{actorId:string}")]
        public IHttpActionResult Get_By_Actor_SmallModel([FromUri] string actorId)
        {
            try
            {
                return Ok(_service.Get_ByActor_SmallModel(actorId));
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetByCategoryId video result", typeof(VideoSmallModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpGet, Route("smallModel/category/{categoryId:string}")]
        public IHttpActionResult Get_By_Category_SmallModel([FromUri] string categoryId)
        {
            try
            {
                return Ok(_service.Get_ByCategory_SmallModel(categoryId));
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetByStudioId video result", typeof(VideoSmallModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpGet, Route("smallModel/studio/{studioId:string}")]
        public IHttpActionResult Get_By_Studio_SmallModel([FromUri] string studioId)
        {
            try
            {
                return Ok(_service.Get_ByStudio_SmallModel(studioId));
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetRandom video result", typeof(VideoSmallModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpGet, Route("smallModel/random")]
        public IHttpActionResult Get_Random_SmallModel()
        {
            try
            {
                return Ok(_service.GetRandom_SmallModel());
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetAll Video result", typeof(IEnumerable<VideoFullModel>))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Video were not found in database")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpGet, Route("fullModel")]
        public IHttpActionResult Get_All_FullModel()
        {
            try
            {
                return Ok(_service.GetAll_FullModel());
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetById video result", typeof(VideoFullModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpGet, Route("fullModel/{videoId:string}")]
        public IHttpActionResult Get_By_Id_FullModel([FromUri] string videoId)
        {
            try
            {
                return Ok(_service.Get_FullModel(videoId));
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetById video result", typeof(VideoItemModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpGet, Route("itemModel/{videoId:string}")]
        public IHttpActionResult Get_By_Id_ItemModel([FromUri] string videoId)
        {
            try
            {
                return Ok(_service.Get_ItemModel(videoId));
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetRandom video result", typeof(VideoItemModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpGet, Route("itemModel/random")]
        public IHttpActionResult Get_Random_ItemModel()
        {
            try
            {
                return Ok(_service.GetRandom_ItemModel());
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /*
        [SwaggerResponse(HttpStatusCode.Created, "Video was successfully added", typeof(VideoFullModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect model")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody] VideoFullModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _service.Create(model);
                return Ok();

            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /*
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed video.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        */
        [HttpPut, Route("{videoId:string}")]
        public IHttpActionResult Update([FromUri] string videoId, [FromBody] VideoFullModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _service.Update(videoId, model);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));

            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /*
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed video.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        */
        [HttpDelete, Route("{videoId:string}")]
        public IHttpActionResult Delete([FromUri] string videoId)
        {
            try
            {
                _service.Delete(videoId);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
