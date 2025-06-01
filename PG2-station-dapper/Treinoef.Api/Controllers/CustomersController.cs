using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Treinoef.Api.Contracts.Customers;
using Treinoef.Services.Interfaces;

namespace Treinoef.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService customerService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CustomerResponseContract>> GetAll()
        {
            return Ok(customerService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerResponseContract> Get([FromRoute] int id)
        {
            var customer = customerService.Get(id);

            if (customer is null) return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<CustomerResponseContract> Create([FromBody] CustomerRequestContract customerRequestContract)
        {
            var createdCustomer = customerService.Create(customerRequestContract);

            return CreatedAtAction(nameof(Get), new { id = createdCustomer.Id }, createdCustomer);
        }
    }
}
