namespace OefeningLes3.Services.Contracts;

public class PokemonRequestContract
{
    public string Naam { get; set; }
    public string Beschrijving { get; set; }
    public SoortEnum Soort { get; set; }
    public ZeldzaamheidEnum Zeldzaamheid { get; set; }
}