using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerRepository repository) : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public ActionResult<CustomerResponseContract> Get([FromRoute] int id)
        {
            return Ok(repository.Get(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerResponseContract>> GetAll()
        {
            return Ok(repository.GetAll());
        }

        [HttpPost]
        public ActionResult Create([FromBody] CustomerRequestContract customerContract)
        {
            var created = repository.Create(customerContract);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update([FromBody] CustomerRequestContract customerContract, [FromRoute] int id)
        {
            repository.Update(customerContract, id);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            repository.Delete(id);
            return Ok();
        }
    }
}
