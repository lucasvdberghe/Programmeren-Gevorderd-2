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
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
