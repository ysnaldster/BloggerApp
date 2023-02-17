using test.Configuration.Containers;

namespace test.Configuration.Base;

public class GenericControllerTestBase 
{
    protected readonly HttpClient HttpClient;

    protected GenericControllerTestBase(PostgresTestContainer postgresTestContainer)
    {
        HttpClient = postgresTestContainer.CreateDefaultClient();
        HttpClient.BaseAddress = new Uri("http://localhost:5082/");
    }
    
}