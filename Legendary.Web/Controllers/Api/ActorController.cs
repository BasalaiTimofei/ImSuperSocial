using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Legendary.Business.Interfaces;
using Legendary.Business.Models.Actor;

namespace Legendary.Web.Controllers.Api
{
    [RoutePrefix("api/actor")]
    public class ActorController : ApiController
    {
        private readonly IActorService _service;
        public ActorController(IActorService service)
        {
            _service = service;
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetAll Actors result", typeof(IEnumerable<ActorFullModel>))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Actor were not found in database")]
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
        [SwaggerResponse(HttpStatusCode.OK, "GetAll Actors result", typeof(IEnumerable<ActorSmallModel>))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Actor were not found in database")]
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
        [SwaggerResponse(HttpStatusCode.OK, "GetById Actor result", typeof(ActorFullModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
         */
        [HttpGet, Route("fullModel/{actorId:string}")]
        public IHttpActionResult Get_By_Id_FullModel([FromUri] string actorId)
        {
            try
            {
                return Ok(_service.Get_FullModel(actorId));
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
        [SwaggerResponse(HttpStatusCode.OK, "GetByCountryId Actor result", typeof(IEnumerable<StudioFullModel>))]
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
        [SwaggerResponse(HttpStatusCode.Created, "Actor was successfully added", typeof(ActorFullModel))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect model")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody] ActorFullModel model)
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
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed actor.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        */
        [HttpPut, Route("{actorId:string}")]
        public IHttpActionResult Update([FromUri] string actorId, [FromBody] ActorFullModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _service.Update(actorId, model);
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
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed actor.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        */
        [HttpDelete, Route("{actorId:string}")]
        public IHttpActionResult Delete([FromUri] string actorId)
        {
            try
            {
                _service.Delete(actorId);
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
