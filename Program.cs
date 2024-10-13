using Microsoft.EntityFrameworkCore;
using WebApi_Minimal1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Database>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("FilmConnStr")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/cats", () =>
{
    var obj1 = new
    {
        title = "cat",
        type = "carnivores"
    };
    var obj2 = new
    {
        title = "lion",
        type = "carnivores"
    };

    var obj = new[]{obj1,obj2};
    return obj;
});

app.MapGet("/movies", async(Database db) => await db.Films.ToListAsync());

app.Run();
