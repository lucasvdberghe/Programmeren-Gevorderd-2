namespace OefeningLes3.Services.Contracts;

public class PokemonResponseContract
{
    public int Id { get; set; }
    public string Naam { get; set; }
    public string Beschrijving { get; set; }
    public SoortEnum Soort { get; set; }
    public ZeldzaamheidEnum Zeldzaamheid { get; set; }
}