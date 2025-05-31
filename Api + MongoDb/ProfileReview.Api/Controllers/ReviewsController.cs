using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileReview.Api.Contracts.Reviews;
using ProfileReview.Services.Exceptions;
using ProfileReview.Services.Interfaces;

namespace ProfileReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController(IReviewService reviewService) : ControllerBase
    {
        // Oké om hier geen resource terug te geven?
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] ReviewRequestContract reviewRequestContract)
        {
            // Geen try-catch voor andere exceptions omwille van ProblemDetails toevoeging?
            try
            {
                await reviewService.CreateAsync(reviewRequestContract);
                return Created();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
