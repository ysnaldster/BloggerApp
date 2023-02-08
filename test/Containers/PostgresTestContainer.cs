using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using test.Setup;

namespace test.Containers;

public class PostgresTestContainer : IAsyncLifetime
{

    private readonly PostgreSqlTestcontainer _postgreSqlTestcontainer;
    //private AppFactoryTestContainer _appFactoryTestContainer;
    //private string _connectionString;

    public PostgresTestContainer()
    {
        //_appFactoryTestContainer = appFactoryTestContainer;
        //_connectionString = connectionString;
        _postgreSqlTestcontainer = new TestcontainersBuilder<PostgreSqlTestcontainer>()
            .WithDatabase(new PostgreSqlTestcontainerConfiguration
            {
                Database = "test_db",
                Username = "postgres",
                Password = "postgres",
            })
            .WithExposedPort("5082")
            .WithImage("postgres:latest")
            .WithCleanUp(true)
            .Build();
        //_connectionString = _postgreSqlTestcontainer.ConnectionString;
    }
    
    private Task ConfigurePostgresqlContainer()
    {
        //_connectionString = _postgreSqlTestcontainer.ConnectionString;
        //_appFactoryTestContainer = new AppFactoryTestContainer(_connectionString);
        return Task.CompletedTask;
    }

    public async Task InitializeAsync()
    {
        await _postgreSqlTestcontainer.StartAsync();
        //await ConfigurePostgresqlContainer();
    }

    public async Task DisposeAsync()
    {
        await _postgreSqlTestcontainer.StopAsync();
        await _postgreSqlTestcontainer.DisposeAsync();
    }
}