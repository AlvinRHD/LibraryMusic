using FluentValidation;
using Library_MusicData.Data;
using Library_MusicData.Models;
using Library_MusicData.Repositories.Album;
using Library_MusicData.Repositories.Artist;
using Library_MusicData.Repositories.Song;
using Library_MusicData.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IDbDataAccess, DbDataAccess>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<ISongRepository, SongRepository>();

//Validations 

builder.Services.AddScoped<IValidator<ArtistModel>, ArtistValidator>();
builder.Services.AddScoped<IValidator<AlbumsModel>, AlbumValidator>();
builder.Services.AddScoped<IValidator<SongsModel>, SongValidator>();

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
