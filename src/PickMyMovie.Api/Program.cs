using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PickMyMovie.Application.Services;
using PickMyMovie.Domain.Interfaces;
using PickMyMovie.Infrastructure.DataAccess;
using PickMyMovie.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieRecommendationService, MovieRecommendationService>();

builder.Services.AddDbContext<PickMyMovieDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("Connection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Connection"))
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await MigrateDatabase();

app.Run();

async Task MigrateDatabase()
{
    await using var scope = app.Services.CreateAsyncScope();

    await DataBaseMigration.MigrateDataBase(scope.ServiceProvider);
}
