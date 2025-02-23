using WebApplication1.Repositories;

namespace WebApplication1;

public class Program {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        // Services for container
        builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
        builder.Services.AddControllers();

        var app = builder.Build();

        // HTTP request pipeline
        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}