using Application.Common.Contracts;
using Application.Service.Contracts;
using System.Web.Http;

namespace Application.UI.Controllers
{
    [RoutePrefix("api/persons")]
    public class PersonController : ApiController
    {
        ICustomerService _customerService;

        public PersonController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }
        [Route("customers")]
        [HttpGet]
        public IHttpActionResult GetAllCustomers(int id)
        {
            id = 1; string password = "123";
            var obj = _customerService.ValidateCustomer(id, password);
            return Ok(obj);
        }
        [Route("getbyid/{id}")]
        //[Route("getbyid")]
        [HttpPost]
        public IHttpActionResult GetPersonById(int id)
        {
            return NotFound();
        }
        [HttpPut]
        [Route("updatePerson")]
        public IHttpActionResult updatePerson()
        {
            return NotFound();
        }
        //[Route("country/getAll")]
        //[HttpGet]
        //public IHttpActionResult GetCountries()
        //{
        //    return NotFound();
        //}
    }
}