using System.Text.Json.Serialization;
using OefeningLes3.Persistence;
using OefeningLes3.Services;
using OefeningLes3.Services.Interfaces;

namespace OefeningLes3.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddSingleton<IPokemonService, PokemonService>();
        // Oke als er een referentie gelegd wordt naar Persistence project?
        builder.Services.AddSingleton<IPokemonRepository, PokemonRepository>();
        builder.Services.AddSingleton<IVideogameService, VideogameService>();
        builder.Services.AddSingleton<IVideogameRepository, VideogameRepository>();
        builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}