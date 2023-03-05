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
using tests.Clients;
using tests.Configuration.Base;
using tests.Utils;

namespace tests.Configuration.Containers;

public class PostgresTestContainer : WebApplicationFactory<Startup>, IAsyncLifetime
{

    private readonly PostgreSqlTestcontainer _postgresqlContainer;
    private TestPosgreSqlClient _clientForTest;
    private string _connectionString;

    public PostgresTestContainer()
    {
        ConfigureEnvironmentVariablesForTests();
        _postgresqlContainer = new TestcontainersBuilder<PostgreSqlTestcontainer>()
            .WithDatabase(new PostgreSqlTestcontainerConfiguration
            {
                Database = EnvironmentManager.PostgresDatabaseName,
                Username = EnvironmentManager.PostgresDatabaseUserName,
                Password = EnvironmentManager.PostgresDatabasePassword,
            })
            .WithExposedPort(EnvironmentManager.PostgresDatabaseExposedPort)
            .WithImage(EnvironmentManager.PostgresDatabaseImage)
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
    
    private void ConfigurePostgresqlContainer()
    {
        _connectionString = _postgresqlContainer.ConnectionString;
        _clientForTest = new TestPosgreSqlClient(_connectionString);
    }

    
    public async Task InitializeAsync()
    {
        await _postgresqlContainer.StartAsync();
        ConfigurePostgresqlContainer();
    }
    
    public new async Task DisposeAsync()
    {
        await _postgresqlContainer.StopAsync();
        await _postgresqlContainer.DisposeAsync();
    }
    
    public async Task PopulateTablesAsync(string schema)
    {
        await _clientForTest.PopulateTables(schema);
    }
    
    public async Task DeleteAllItemsFromTableAsync()
    {
  
        await _clientForTest.DeleteAllItemsFromTableAsync();
    }
    
    private static void ConfigureEnvironmentVariablesForTests()
    {
        EnvironmentManager.SetEnvironmentVariables();
    }
    
}