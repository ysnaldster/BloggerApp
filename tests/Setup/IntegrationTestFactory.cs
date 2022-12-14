using System.Data;
using BlogApplication.Infrastructure.Context;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace tests.Setup;

public class IntegrationTestFactory : WebApplicationFactory<BlogApplicationContext>
{
    private readonly TestcontainerDatabase _container;
    
    public IntegrationTestFactory()
    {
        _container = new TestcontainersBuilder<PostgreSqlTestcontainer>()
            .WithDatabase(new PostgreSqlTestcontainerConfiguration
            {
                Database = "test_db",
                Username = "postgres",
                Password = "postgres",
            })
            .WithImage("postgres:latest")
            .WithCleanUp(true)
            .Build();
    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            //services.RemoveDbContext<TDbContext>();
            services.AddSingleton<IDbConnection>(_ =>
                new NpgsqlConnection(
                    "User ID=postgres;Password=admin;Host=localhost;Port=5555;Database=blog_application_db;"));
            //services.AddDbContext<TDbContext>(options => { options.UseNpgsql(_container.ConnectionString); });
            //services.AddTransient<BlogApplicationContext>();
        });
    }
    
    public async Task InitializeAsync() => await _container.StartAsync();

    public new async Task DisposeAsync() => await _container.DisposeAsync();
}