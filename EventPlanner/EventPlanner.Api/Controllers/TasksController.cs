using EventPlanner.Api.Contracts.Task;
using EventPlanner.Services.Exceptions;
using EventPlanner.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(ITaskService taskService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskResponseContract>>> GetAll()
        {
            return Ok(await taskService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResponseContract>> GetById([FromRoute] int id)
        {
            var taskResponse = await taskService.GetByIdAsync(id);

            if (taskResponse is null) return NotFound();

            return Ok(taskResponse);
        }

        [HttpPost]
        public async Task<ActionResult<TaskResponseContract>> Create([FromBody] TaskRequestContract taskRequestContract)
        {
            try
            {
                var createdTask = await taskService.CreateAsync(taskRequestContract);
                return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] TaskRequestContract taskRequestContract)
        {
            try
            {
                await taskService.UpdateAsync(id, taskRequestContract);
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

        [HttpPatch("{id}/status")]
        public async Task<ActionResult> PatchStatus([FromRoute] int id, [FromBody] TaskPatchRequestContract taskPatchRequestContract)
        {
            try
            {
                await taskService.PatchStatusAsync(id, taskPatchRequestContract);
                return NoContent();
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
                await taskService.DeleteAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
