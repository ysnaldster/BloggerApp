using test.Configuration.Containers;

namespace test.Configuration.Base;

public class TestConfigurationBase : IAsyncLifetime
{
    
    private readonly PostgresTestContainer _postgresContainer;
    protected readonly HttpClient HttpClient;


    protected TestConfigurationBase(PostgresTestContainer postgresContainer)
    {
        _postgresContainer = postgresContainer;
        HttpClient = postgresContainer.CreateDefaultClient();
        HttpClient.BaseAddress = new Uri("http://localhost:5082/");
    }

    public async Task InitializeAsync()
    {
         await _postgresContainer.PopulateTablesAsync();
    }

    public async Task DisposeAsync()
    {
        await _postgresContainer.DeleteAllItemsFromTableAsync();
    }
}