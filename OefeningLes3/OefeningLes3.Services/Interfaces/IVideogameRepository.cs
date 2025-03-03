using OefeningLes3.Services.Contracts;

namespace OefeningLes3.Services.Interfaces;

public interface IVideogameRepository
{
    IEnumerable<VideogameResponseContract> GetAll();
    VideogameResponseContract Get(int id);
    VideogameResponseContract Create(VideogameResponseContract videogame);
    void Update(VideogameResponseContract videogame, int id);
    void Delete(int id);
}