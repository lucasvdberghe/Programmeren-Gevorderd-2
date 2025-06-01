using EventPlanner.Services.Interfaces;
using EventPlanner.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditsController(IAuditService auditService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditEntry>>> GetAll([FromQuery] string? subject, [FromQuery] string? action)
        {
            return Ok(await auditService.GetAuditTrailAsync(subject, action));
        }
    }
}
