using EventPlanner.Api.Contracts.Location;
using EventPlanner.Services.Exceptions;
using EventPlanner.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController(ILocationService locationService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationResponseContract>>> GetAll()
        {
            return Ok(await locationService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationResponseContract>> GetById([FromRoute] int id)
        {
            var locationResponse = await locationService.GetByIdAsync(id);

            if (locationResponse is null) return NotFound();

            return Ok(locationResponse);
        }

        [HttpPost]
        public async Task<ActionResult<LocationResponseContract>> Create([FromBody] LocationRequestContract locationRequestContract)
        {
            try
            {
                var createdLocation = await locationService.CreateAsync(locationRequestContract);
                return CreatedAtAction(nameof(GetById), new { id = createdLocation.Id }, createdLocation);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] LocationRequestContract locationRequestContract)
        {
            try
            {
                await locationService.UpdateAsync(id, locationRequestContract);
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
                await locationService.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
