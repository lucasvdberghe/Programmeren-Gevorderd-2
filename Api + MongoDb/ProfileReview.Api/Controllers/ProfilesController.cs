using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileReview.Api.Contracts.Profiles;
using ProfileReview.Services.Exceptions;
using ProfileReview.Services.Interfaces;

namespace ProfileReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController(IProfileService profileService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileResponseContract>> GetAsync([FromRoute] string id)
        {
            var profile = await profileService.GetByIdAsync(id);

            if (profile is null) return NotFound();

            return Ok(profile);
        }

        [HttpPost]
        public async Task<ActionResult<ProfileResponseContract>> CreateAsync([FromBody] ProfileRequestContract profileRequestContract)
        {
            // Geen try-catch voor andere exceptions omwille van ProblemDetails toevoeging?
            try
            {
                var createdProfile = await profileService.CreateAsync(profileRequestContract);
                return CreatedAtAction(nameof(GetAsync), new { id = createdProfile.Id }, createdProfile);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] string id, [FromBody] ProfileRequestContract profileRequestContract)
        {
            // Geen try-catch voor andere exceptions omwille van ProblemDetails toevoeging?
            try
            {
                await profileService.UpdateAsync(id, profileRequestContract);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
