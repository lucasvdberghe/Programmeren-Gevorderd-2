using OefeningLes3.Services.Contracts;

namespace OefeningLes3.Services.Interfaces;

public interface IPokemonRepository
{
    PokemonResponseContract Get(int id);
    IEnumerable<PokemonResponseContract> GetAll();
    IEnumerable<PokemonResponseContract> GetMany(List<int> ids);
    PokemonResponseContract Create(PokemonResponseContract pokemon);
    void Update(PokemonResponseContract pokemon, int id);
    void Delete(int id);
    bool IsNaamUniek(string pokemonNaam);
}