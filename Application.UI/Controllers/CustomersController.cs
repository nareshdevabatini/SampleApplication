using Application.Common.Contracts;
using Application.Common.Filters;
using Application.Model.DTO;
using Application.Service.Contracts;
using System.Web.Http;

namespace Application.UI.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
       // ILogService loggerService;
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }
        //public CustomersController(ILogService loggerService, ICustomerService customerService)
        //{
        //    this.loggerService = loggerService;
        //    this._customerService = customerService;
        //}

        /// <summary>
        /// To validate Customer
        /// </summary>
        /// <returns></returns>

        //[EnableCors]
        //[AcceptVerbs("GET", "POST")]
        [Route("customer/getall")]
        [HttpGet]
        public IHttpActionResult ValidateCustomer(int id=1)
        {
            id = 1; string password = "123";
            //loggerService.Logger().Info("Calling with parameter as : id and password: " + id + " and " + password);
            var obj=_customerService.ValidateCustomer(id, password);
            return Ok(obj);
        }

        /// <summary>
        /// To Save Customer
        /// </summary>
        /// <returns></returns>
        [EnableCors]
        [HttpPost]
        [Route("postdata")]
        public IHttpActionResult PostCustomer(CustomerDTO customer)
        {
            //loggerService.Logger().Info("Calling with parameter as : customer: " + customer);
            var obj= _customerService.SaveOrUpdateCustomer(customer);
            return Ok(obj);
        }
       
        [HttpPut]
        [Route("updatePerson")]
        public void updatePerson()
        {
            
        }
        
    }
}
