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
        throw new NotImplementedException();
    }

    public void Update(VideogameResponseContract videogame, int id)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        _videogames.Remove(id);
    }
}