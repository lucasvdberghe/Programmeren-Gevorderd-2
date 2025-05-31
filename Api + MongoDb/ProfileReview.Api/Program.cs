using MongoDB.Driver;
using ProfileReview.Services;
using ProfileReview.Services.Interfaces;
using ProfileReview.Storage;
using ProfileReview.Storage.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddControllers().AddMvcOptions(options => {
        options.SuppressAsyncSuffixInActionNames = false; 
    });
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddMongoDB<ProfileReviewDbContext>(
    new MongoClient(builder.Configuration.GetConnectionString("MongoDbConnection")), builder.Configuration.GetValue<string>("MongoDatabase") ?? throw new ArgumentNullException());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
