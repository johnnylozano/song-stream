using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SongStream.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Songs") ?? "Data Source=Songs.db";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlite<SongDb>(connectionString);
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "SongStream API",
        Description = "Streaming songs",
        Version = "v1",
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SongStream API V1");
});

app.MapGet("/", () => "Hello World!");
app.MapGet("/songs", async (SongDb db) => await db.Songs.ToListAsync());
app.MapGet("/song/{id}", async (SongDb db, int id) => await db.Songs.FindAsync(id));
app.MapPost("/song", async (SongDb db, Song song) =>
{
    await db.Songs.AddAsync(song);
    await db.SaveChangesAsync();
    return Results.Created($"/song/{song.Id}", song);
});
app.MapPut("/song/{id}", async (SongDb db, Song updatesong, int id) =>
{
      var song = await db.Songs.FindAsync(id);
      if (song is null) return Results.NotFound();
      song.SongName = updatesong.SongName;
      song.SongArtist = updatesong.SongArtist;
      song.ImageSrc = updatesong.ImageSrc;
      song.AudioSrc = updatesong.AudioSrc;
      await db.SaveChangesAsync();
      return Results.NoContent();
});
app.MapDelete("/song/{id}", async (SongDb db, int id) =>
{
   var song = await db.Songs.FindAsync(id);
   if (song is null)
   {
      return Results.NotFound();
   }
   db.Songs.Remove(song);
   await db.SaveChangesAsync();
   return Results.Ok();
});

app.Run();
