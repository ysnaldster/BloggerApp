using BlogApplication.Api;
using BlogApplication.Infrastructure.Context;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using test.Configuration.Clients;
using test.Setup;

namespace test.Configuration.Containers;

public class PostgresTestContainer : WebApplicationFactory<Startup>, IAsyncLifetime
{

    private readonly PostgreSqlTestcontainer _postgresqlContainer;
    private TestPostgresqlClient _clientForTest;
    //private string _connectionString = "Host = localhost; Port = 5432; Database = test_db; Username = postgres; Password = postgres";

    public PostgresTestContainer()
    {
        _postgresqlContainer = new TestcontainersBuilder<PostgreSqlTestcontainer>()
            .WithDatabase(new PostgreSqlTestcontainerConfiguration
            {
                Database = "test_db",
                Username = "postgres",
                Password = "postgres",
            })
            .WithExposedPort("5432")
            .WithImage("postgres:latest")
            .WithCleanUp(true)
            .Build();
    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveDbContext<BlogApplicationContext>();
            services.AddDbContext<BlogApplicationContext>(options => { options.UseNpgsql(_postgresqlContainer.ConnectionString); });
            services.EnsureDbCreated<BlogApplicationContext>();
        });
    }
    
    public async Task InitializeAsync()
    {
        await _postgresqlContainer.StartAsync();
        //await ConfigurePostgresqlContainer();
    }

    private async Task ConfigurePostgresqlContainer()
    {
        //_connectionString = _postgresqlContainer.ConnectionString;
        //_clientForTest = new TestPostgresqlClient(_connectionString);
        await _clientForTest.CreateTablesIfNotExists();
    }

    public async Task DisposeAsync()
    {
        await _postgresqlContainer.StopAsync();
        await _postgresqlContainer.DisposeAsync();
    }

    public async Task PopulateTablesAsync()
    {
        await _clientForTest.PopulateTables();
    }

    public async Task DeleteAllItemsFromTablesAsync()
    {
        await _clientForTest.DeleteAllItemsFromTablesAsync();
    }

    public async Task TruncateAllTablesAndRestartSequencesAsync()
    {
        await _clientForTest.TruncateAllTablesAndRestartSequencesAsync();
    }

}