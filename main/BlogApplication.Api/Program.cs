using BlogApplication.Api.Context;
using BlogApplication.Domain.interfaces;
using BlogApplication.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNpgsql<BlogApplicationContext>(builder.Configuration.GetConnectionString("blog_application_db"));
// For use of user property DateTime
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Dependencies Inyection
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<IPost, PostService>();

var app = builder.Build();

app.MapGet("/dbconnection", async ([FromServices] 
    BlogApplicationContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();
//Custom Middleware
//app.UseWelcomePage();

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
