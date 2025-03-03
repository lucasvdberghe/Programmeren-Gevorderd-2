using OefeningLes3.Services.Contracts;
using OefeningLes3.Services.Interfaces;

namespace OefeningLes3.Services;

public class PokemonService(IPokemonRepository pokemonRepository, IVideogameRepository videogameRepository) : IPokemonService
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
        bool isUniekePokemonNaam = pokemonRepository.IsNaamUniek(pokemon.Naam);

        if (isUniekePokemonNaam)
        {
            var newPokemon = pokemon.Map();
            var createdPokemon = pokemonRepository.Create(newPokemon);
            return createdPokemon;
        }
        else
        {
            throw new Exception("Er bestaat al een pokemon met die naam");
        }
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
        bool isPokemonInGebruik = videogameRepository.IsPokemonAanwezig(id);
        if (!isPokemonInGebruik)
        {
            pokemonRepository.Delete(id);            
        }
    }
}