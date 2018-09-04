using System.Web.Http;
using ListaTelefonica.Domain;
using ListaTelefonica.Repository;
using ListaTelefonicaApi.Models;

namespace ListaTelefonicaApi.Controllers
{
    public class CarriersController : ApiController
    {
        // GET api/carriers
        public IHttpActionResult Get()
        {
            var repository = new CarrierRepository();
            var carriers = repository.List();
            var models = carriers.ToModel();

            return Ok(models);
        }
    }
}
