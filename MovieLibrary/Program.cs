using Microsoft.EntityFrameworkCore;
using MovieLibrary.Database.Context;
using MovieLibrary.Interfaces;
using MovieLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

void ConfigureServices(IServiceCollection services)
{
    // Register the DbContext and IConfiguration services
    services.AddDbContext<MovieLibraryContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MovieLibraryContext")));
    services.AddSingleton(builder.Configuration);

    services.AddAutoMapper(typeof(Program));
    
    services.AddScoped<IMovieService, MovieService>();

    services.AddControllers();
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build() ;

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
