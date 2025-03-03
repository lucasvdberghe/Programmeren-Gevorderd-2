using Microsoft.AspNetCore.Mvc;
using OefeningLes3.Services.Contracts;
using OefeningLes3.Services.Interfaces;

namespace OefeningLes3.Api.Controllers;

[ApiController]
[Route("Api/videogames")]
public class VideogameController(IVideogameService videogameService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<VideogameResponseContract>> GetAll()
    {
        return Ok(videogameService.GetAll());
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<VideogameResponseContract> Get([FromRoute] int id)
    {
        return Ok(videogameService.Get(id));
    }

    [HttpPost]
    public ActionResult<VideogameResponseContract> Create([FromBody] VideogameRequestContract videogame)
    {
        var createdVideogame = videogameService.Create(videogame);
        return CreatedAtAction(nameof(Get), new { id = createdVideogame.Id }, createdVideogame);
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update([FromBody] VideogameRequestContract videogame, [FromRoute] int id)
    {
        videogameService.Update(videogame, id);
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        videogameService.Delete(id);
        return NoContent();
    }
}