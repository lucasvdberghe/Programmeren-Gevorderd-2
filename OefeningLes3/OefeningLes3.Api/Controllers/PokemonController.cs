using Microsoft.AspNetCore.Mvc;
using OefeningLes3.Services.Contracts;
using OefeningLes3.Services.Interfaces;

namespace OefeningLes3.Api.Controllers;

[ApiController]
[Route("Api/pokemons")]
public class PokemonController(IPokemonService pokemonService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<PokemonResponseContract>> GetAll()
    {
        return Ok(pokemonService.GetAll());
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<PokemonResponseContract> Get([FromRoute] int id)
    {
        return Ok(pokemonService.Get(id));
    }

    [HttpPost]
    public ActionResult<PokemonResponseContract> Create([FromBody] PokemonRequestContract pokemonRequestContract)
    {
        try
        {
            var newPokemon = pokemonService.Create(pokemonRequestContract);
            return CreatedAtAction(nameof(Get), new { id = newPokemon.Id }, newPokemon);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update([FromBody] PokemonRequestContract pokemonRequestContract, [FromRoute] int id)
    {
        pokemonService.Update(pokemonRequestContract, id);
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        pokemonService.Delete(id);
        return NoContent();
    }
}