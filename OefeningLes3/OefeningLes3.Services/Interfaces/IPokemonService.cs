using OefeningLes3.Services.Contracts;

namespace OefeningLes3.Services.Interfaces;

public interface IPokemonService
{
    PokemonResponseContract Get(int id);
    IEnumerable<PokemonResponseContract> GetAll();
    PokemonResponseContract Create(PokemonRequestContract pokemon);
    void Update(PokemonRequestContract pokemon, int id);
    void Delete(int id);
}