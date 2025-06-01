using EventPlanner.Api.Contracts.Event;
using EventPlanner.Services.Exceptions;
using EventPlanner.Services.Interfaces;
using EventPlanner.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController(IEventService eventService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventResponseContract>>> GetAll()
        {
            return Ok(await eventService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventResponseContract>> GetById([FromRoute] int id)
        {
            var eventResponse = await eventService.GetByIdAsync(id);

            if (eventResponse is null) return NotFound();

            return Ok(eventResponse);
        }

        [HttpPost]
        public async Task<ActionResult<EventResponseContract>> Create([FromBody] EventRequestContract eventRequestContract)
        {
            try
            {
                var createdEvent = await eventService.CreateAsync(eventRequestContract);
                return CreatedAtAction(nameof(GetById), new { id = createdEvent.Id }, createdEvent);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] EventRequestContract eventRequestContract)
        {
            try
            {
                await eventService.UpdateAsync(id, eventRequestContract);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await eventService.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}/summaryreport")]
        public async Task<ActionResult<SummaryReportDto>> GetSummaryReport([FromRoute] int id)
        {
            var summary = await eventService.GetSummaryReportAsync(id);

            if (summary is null) return NotFound();

            return summary;
        }
    }
}
