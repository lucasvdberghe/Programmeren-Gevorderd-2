using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Treinoef.Api.Contracts.Subscriptions;
using Treinoef.Services.Exceptions;
using Treinoef.Services.Interfaces;

namespace Treinoef.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController(ISubscriptionService subscriptionService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<SubscriptionResponseContract>> GetAll()
        {
            return Ok(subscriptionService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<SubscriptionResponseContract> Get([FromRoute] int id)
        {
            var subscription = subscriptionService.Get(id);

            if (subscription is null) return NotFound();

            return Ok(subscription);
        }

        [HttpPost]
        public ActionResult<SubscriptionResponseContract> Create([FromBody] SubscriptionRequestContract subscriptionRequestContract)
        {
            try
            {
                var createdSubscription = subscriptionService.Create(subscriptionRequestContract);

                return CreatedAtAction(nameof(Get), new { id = createdSubscription.Id }, createdSubscription);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
