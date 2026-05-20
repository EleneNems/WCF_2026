using Microsoft.EntityFrameworkCore;
using MovieApiComparison.Data;
using MovieApiComparison.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.MapGet("/minimal/movies", async (MovieDbContext db) =>
{
    return await db.Movies.ToListAsync();
})
.WithTags("Minimal API - Movies");

app.MapGet("/minimal/movies/{id}", async (int id, MovieDbContext db) =>
{
    var movie = await db.Movies.FindAsync(id);

    return movie is not null
        ? Results.Ok(movie)
        : Results.NotFound();
})
.WithTags("Minimal API - Movies");

app.MapPost("/minimal/movies", async (Movie movie, MovieDbContext db) =>
{
    db.Movies.Add(movie);
    await db.SaveChangesAsync();

    return Results.Created($"/minimal/movies/{movie.Id}", movie);
})
.WithTags("Minimal API - Movies");

app.MapPut("/minimal/movies/{id}/rating", async (int id, double rating, MovieDbContext db) =>
{
    var movie = await db.Movies.FindAsync(id);

    if (movie is null)
        return Results.NotFound();

    movie.Rating = rating;
    await db.SaveChangesAsync();

    return Results.Ok(movie);
})
.WithTags("Minimal API - Movies");

app.MapDelete("/minimal/movies/{id}", async (int id, MovieDbContext db) =>
{
    var movie = await db.Movies.FindAsync(id);

    if (movie is null)
        return Results.NotFound();

    db.Movies.Remove(movie);
    await db.SaveChangesAsync();

    return Results.NoContent();
})
.WithTags("Minimal API - Movies");

app.Run();