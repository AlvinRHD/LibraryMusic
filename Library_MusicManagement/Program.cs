using FluentValidation;
using Library_MusicData.Data;
using Library_MusicData.Models;
using Library_MusicData.Repositories.Artist;
using Library_MusicData.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IDbDataAccess, DbDataAccess>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();

//Validations 

builder.Services.AddScoped<IValidator<ArtistModel>, ArtistValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
