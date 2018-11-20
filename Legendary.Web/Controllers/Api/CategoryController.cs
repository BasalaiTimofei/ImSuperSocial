using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Legendary.Business.Interfaces;
using Legendary.Business.Models;

namespace Legendary.Web.Controllers.Api
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        /*
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.OK, "GetAll Categories result", typeof(IEnumerable<Category>))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Category were not found in database")]
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
        [SwaggerResponse(HttpStatusCode.OK, "GetById Category result", typeof(Category))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect Id")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
         */
        [HttpGet, Route("{categoryId:string}")]
        public IHttpActionResult Get([FromUri] string categoryId)
        {
            try
            {
                return Ok(_service.Get(categoryId));
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
        [SwaggerResponse(HttpStatusCode.Created, "Category was successfully added", typeof(Category))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Incorrect model")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Unhandled exception has been thrown during the request.")]
        */
        [HttpPost, Route("")]
        public IHttpActionResult Create([FromBody] Category model)
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
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed Category.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        */
        [HttpPut, Route("{categoryId:string}")]
        public IHttpActionResult Update([FromUri] string categoryId, [FromBody] Category model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _service.Update(categoryId, model);
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
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed Category.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        */
        [HttpDelete, Route("{categoryId:string}")]
        public IHttpActionResult Delete([FromUri] string categoryId)
        {
            try
            {
                _service.Delete(categoryId);
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
