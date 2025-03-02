namespace OefeningLes3.Services.Contracts;

public static class MappingExtension
{
    public static PokemonResponseContract Map(this PokemonRequestContract requestContract)
    {
        return new PokemonResponseContract()
        {
            Naam = requestContract.Naam,
            Beschrijving = requestContract.Beschrijving,
            Soort = requestContract.Soort,
            Zeldzaamheid = requestContract.Zeldzaamheid
        };
    }
}