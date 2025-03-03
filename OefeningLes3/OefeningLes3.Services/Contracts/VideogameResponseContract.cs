namespace OefeningLes3.Services.Contracts;

public class VideogameResponseContract
{
    public int Id { get; set; }
    public string Naam { get; set; }
    public string Beschrijving { get; set; }
    public DateTime DatumUitgave { get; set; }
    public List<PokemonResponseContract> Pokemons { get; set; } = new();
}