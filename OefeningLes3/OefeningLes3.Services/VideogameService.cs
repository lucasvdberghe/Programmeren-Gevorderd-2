using OefeningLes3.Services.Contracts;
using OefeningLes3.Services.Interfaces;

namespace OefeningLes3.Services;

public class VideogameService(IVideogameRepository videogameRepository, IPokemonRepository pokemonRepository) : IVideogameService
{
    public IEnumerable<VideogameResponseContract> GetAll()
    {
        return videogameRepository.GetAll();
    }

    public VideogameResponseContract Get(int id)
    {
        return videogameRepository.Get(id);
    }

    public VideogameResponseContract Create(VideogameRequestContract videogame)
    {
        bool isUniekeVideogameNaam = videogameRepository.IsNaamUniek(videogame.Naam);
        
        if (isUniekeVideogameNaam)
        {
            var pokemons = pokemonRepository.GetMany(videogame.PokemonIds);
            var newVideogame = new VideogameResponseContract()
            {
                Naam = videogame.Naam,
                Beschrijving = videogame.Beschrijving,
                DatumUitgave = videogame.DatumUitgave,
                Pokemons = pokemons.ToList()
            };

            var createdVideogame = videogameRepository.Create(newVideogame);

            return createdVideogame;
        }
        else
        {
            throw new Exception("Er bestaat al een videogame met die titel");
        }
    }

    public void Update(VideogameRequestContract videogame, int id)
    {
        var pokemons = pokemonRepository.GetMany(videogame.PokemonIds);
        var updatedVideogame = new VideogameResponseContract()
        {
            Id = id,
            Naam = videogame.Naam,
            Beschrijving = videogame.Beschrijving,
            DatumUitgave = videogame.DatumUitgave,
            Pokemons = pokemons.ToList()
        };
        
        videogameRepository.Update(updatedVideogame, id);
    }

    public void Delete(int id)
    {
        videogameRepository.Delete(id);
    }
}