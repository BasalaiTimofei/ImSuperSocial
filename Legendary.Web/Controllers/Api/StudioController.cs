using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Legendary.Business.Interfaces;
using Legendary.Business.Models.Studio;

namespace Legendary.Web.Controllers.Api
{
    [RoutePrefix("api/studio")]
    public class StudioController : ApiController
    {
        private readonly IStudioService _service;
        public StudioController(IStudioService service)
        {
            _service = service;
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetAll Studies result", typeof(IEnumerable<StudioFullModel>))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Video were not found in database")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpGet, Route("fullModel")]
        public IHttpActionResult GetAll_FullModel()
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
        [SwaggerResponse(HttpStatusCode.OK, "GetAll Studies result", typeof(IEnumerable<StudioSmallModel>))]
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
        [SwaggerResponse(HttpStatusCode.OK, "GetById studio result", typeof(StudioFullModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
         */
        [HttpGet, Route("fullModel/{studioId:string}")]
        public IHttpActionResult Get_By_Id_FullModel([FromUri] string studioId)
        {
            try
            {
                return Ok(_service.Get_FullModel(studioId));
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
        [SwaggerResponse(HttpStatusCode.OK, "GetByCountryId studio result", typeof(IEnumerable<StudioFullModel>))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpGet, Route("fullModel/country/{countryId:string}")]
        public IHttpActionResult Get_By_Country_FullModel([FromUri] string countryId)
        {
            try
            {
                return Ok(_service.GetAll_By_Country_FullModel(countryId));
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
        [SwaggerResponse(HttpStatusCode.Created, "Studio was successfully added", typeof(StudioFullModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect model")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody] StudioFullModel model)
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
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed studio.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        */
        [HttpPut, Route("{studioId:string}")]
        public IHttpActionResult Update([FromUri] string studioId, [FromBody] StudioFullModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _service.Update(studioId, model);
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
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed studio.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        */
        [HttpDelete, Route("{studioId:string}")]
        public IHttpActionResult Delete([FromUri] string studioId)
        {
            try
            {
                _service.Delete(studioId);
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
