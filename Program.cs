using BlogApplication.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNpgsql<BlogApplicationContext>(builder.Configuration.GetConnectionString("blog_application_db"));
// For use of user property DateTime
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = builder.Build();

app.MapGet("/dbconnection", async ([FromServices] 
    BlogApplicationContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});


app.Run();
