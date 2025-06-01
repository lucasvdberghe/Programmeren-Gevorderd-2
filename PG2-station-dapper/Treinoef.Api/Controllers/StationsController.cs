using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Treinoef.Api.Contracts.Stations;
using Treinoef.Services.Exceptions;
using Treinoef.Services.Interfaces;

namespace Treinoef.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController(IStationService stationService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<StationResponseContract>> GetAll()
        {
            return Ok(stationService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<StationResponseContract> Get([FromRoute] int id)
        {
            var station = stationService.Get(id);

            if (station is null) return NotFound();

            return Ok(station);
        }

        [HttpPost]
        public ActionResult<StationResponseContract> Create([FromBody] StationRequestContract stationRequestContract)
        {
            var createdStation = stationService.Create(stationRequestContract);

            return CreatedAtAction(nameof(Get), new { id = createdStation.Id }, createdStation);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] StationRequestContract stationRequestContract)
        {
            try
            {
                stationService.Update(id, stationRequestContract);

                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
