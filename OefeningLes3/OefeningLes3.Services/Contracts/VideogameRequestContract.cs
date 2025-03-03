namespace OefeningLes3.Services.Contracts;

public class VideogameRequestContract
{
    public string Naam { get; set; }
    public string Beschrijving { get; set; }
    public DateTime DatumUitgave { get; set; }
    public List<int> PokemonIds { get; set; } = new();
}