using OefeningLes3.Services.Contracts;
using OefeningLes3.Services.Interfaces;

namespace OefeningLes3.Services;

public class PokemonService(IPokemonRepository pokemonRepository) : IPokemonService
{
    public PokemonResponseContract Get(int id)
    {
        return pokemonRepository.Get(id);
    }

    public IEnumerable<PokemonResponseContract> GetAll()
    {
        return pokemonRepository.GetAll();
    }

    public PokemonResponseContract Create(PokemonRequestContract pokemon)
    {
        var newPokemon = pokemon.Map();
        var createdPokemon = pokemonRepository.Create(newPokemon);
        return createdPokemon;
    }

    public void Update(PokemonRequestContract pokemon, int id)
    {
        var updatedPokemon = pokemon.Map();
        updatedPokemon.Id = id;
        // Id nog meegeven als argument?
        pokemonRepository.Update(updatedPokemon, id);
    }

    public void Delete(int id)
    {
        pokemonRepository.Delete(id);
    }
}