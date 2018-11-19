using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Legendary.Business.Interfaces;
using Legendary.Business.Models;

namespace Legendary.Web.Controllers.Api
{
    public class CountryController : ApiController
    {
        private readonly ICountryService _service;
        public CountryController(ICountryService service)
        {
            _service = service;
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetAll Countries result", typeof(IEnumerable<Country>))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Country were not found in database")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
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
        [SwaggerResponse(HttpStatusCode.OK, "GetById Country result", typeof(Country))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
         */
        [HttpGet, Route("{countryId:string}")]
        public IHttpActionResult Get_By_Id_FullModel([FromUri] string countryId)
        {
            try
            {
                return Ok(_service.Get(countryId));
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
        [SwaggerResponse(HttpStatusCode.Created, "Country was successfully added", typeof(Country))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect model")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody] Country model)
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
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed Country.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        */
        [HttpPut, Route("{countryId:string}")]
        public IHttpActionResult Update([FromUri] string countryId, [FromBody] Country model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _service.Update(countryId, model);
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
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed Country.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        */
        [HttpDelete, Route("{countryId:string}")]
        public IHttpActionResult Delete([FromUri] string countryId)
        {
            try
            {
                _service.Delete(countryId);
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
