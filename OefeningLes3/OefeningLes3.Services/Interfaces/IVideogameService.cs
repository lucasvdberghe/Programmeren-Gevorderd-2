using OefeningLes3.Services.Contracts;

namespace OefeningLes3.Services.Interfaces;

public interface IVideogameService
{
    IEnumerable<VideogameResponseContract> GetAll();
    VideogameResponseContract Get(int id);
    VideogameResponseContract Create(VideogameRequestContract videogame);
    void Update(VideogameRequestContract videogame, int id);
    void Delete(int id);
}