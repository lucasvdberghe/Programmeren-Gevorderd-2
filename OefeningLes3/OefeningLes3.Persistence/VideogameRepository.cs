using OefeningLes3.Services.Contracts;
using OefeningLes3.Services.Interfaces;

namespace OefeningLes3.Persistence;

public class VideogameRepository : IVideogameRepository
{
    private readonly Dictionary<int, VideogameResponseContract> _videogames = new();
    
    public IEnumerable<VideogameResponseContract> GetAll()
    {
        return _videogames.Values.ToList();
    }

    public VideogameResponseContract Get(int id)
    {
        return _videogames[id];
    }

    public VideogameResponseContract Create(VideogameResponseContract videogame)
    {
        var newId = _videogames.Any() ? _videogames.Keys.Max() + 1 : 1;
        videogame.Id = newId;
        _videogames.Add(videogame.Id, videogame);
        return videogame;
    }

    public void Update(VideogameResponseContract videogame, int id)
    {
        _videogames[id] = videogame;
    }

    public void Delete(int id)
    {
        _videogames.Remove(id);
    }

    public bool IsPokemonAanwezig(int id)
    {
        return _videogames.Values.Any(videogame => videogame.Pokemons.Select(pokemon => pokemon.Id).Contains(id));
    }

    public bool IsNaamUniek(string videogameNaam)
    {
        return _videogames.Values.All(videogame => videogame.Naam != videogameNaam);
    }
}