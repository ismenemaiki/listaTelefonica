using System;
using System.Net;
using System.Web.Http;
using ListaTelefonica.Repository;
using ListaTelefonicaApi.Models;

namespace ListaTelefonicaApi.Controllers
{
    public class ContactsController : ApiController
    {
        [HttpGet]
        [Route("api/contacts")]
        public IHttpActionResult List()
        {
            var repository = new ContactRepository();
            var contacts = repository.List();
            var models = contacts.ToModel();

            return Ok(models);
        }

        [HttpGet]
        [Route("api/contact")]
        public IHttpActionResult Get([FromUri]string name)
        {
            var repository = new ContactRepository();
            var contacts = repository.ListByName(name);
            var models = contacts.ToModel();

            return Ok(models);
        }

        [HttpPost]
        [Route("api/contact")]
        public IHttpActionResult Add(ContactModel model)
        {
            try
            {
                var contact = model.ToDomain();
                contact.Repository = new ContactRepository();
                contact.Save();

                return Content(HttpStatusCode.NoContent, string.Empty);
            }
            catch(ArgumentNullException)
            {
                return InternalServerError();
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        //METÓDO UPDATE COM POST
        [HttpPost]
        [Route("api/contact/update")]
        public IHttpActionResult Update(ContactModel model)
        {
            try
            {
                var contact = model.ToDomain();
                contact.Repository = new ContactRepository();
                contact.Update();

                return Content(HttpStatusCode.NoContent, string.Empty);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        //-----------------------------------------
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]string value)
        {
            return this.Ok();
        }

        [HttpPost]
        [Route("api/contact/delete/{id}")]
        public IHttpActionResult Delete(long id)
        {
            try
            {
                var repository = new ContactRepository();
                repository.Delete(id);

                return Content(HttpStatusCode.NoContent, string.Empty);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
