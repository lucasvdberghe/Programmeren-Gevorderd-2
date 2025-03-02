using OefeningLes3.Services.Contracts;
using OefeningLes3.Services.Interfaces;

namespace OefeningLes3.Persistence;

public class PokemonRepository : IPokemonRepository
{
    private readonly Dictionary<int, PokemonResponseContract> _pokemons = new();


    public PokemonResponseContract Get(int id)
    {
        return _pokemons[id];
    }

    public IEnumerable<PokemonResponseContract> GetAll()
    {
        return _pokemons.Values.ToList();
    }

    public PokemonResponseContract Create(PokemonResponseContract pokemon)
    {
        int newId = _pokemons.Any() ? _pokemons.Keys.Max() + 1 : 1;
        pokemon.Id = newId;
        _pokemons.Add(pokemon.Id, pokemon);
        return _pokemons[pokemon.Id];
    }

    public void Update(PokemonResponseContract pokemon, int id)
    {
        _pokemons[id] = pokemon;
    }

    public void Delete(int id)
    {
        _pokemons.Remove(id);
    }
}