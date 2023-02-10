using test.Configuration.Containers;
using test.Setup;

namespace test.BlogApplication.Api.Controllers2;

public class ControllerTestBase : IAsyncLifetime
{
    protected HttpClient HttpClient;
    protected PostgresTestContainer PostgresTestContainer;
    
    public ControllerTestBase( PostgresTestContainer postgresTestContainer)
    {
        HttpClient = postgresTestContainer.CreateDefaultClient();
        PostgresTestContainer = postgresTestContainer;
    }

    //Se ejecuta despues del constructor
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
        //ostgresTestContainer 
        //throw new NotImplementedException();
    }
    
    //Se ejecuta despues de terminar la prueba
    public Task DisposeAsync()
    {
        return Task.CompletedTask;
        //throw new NotImplementedException();
    }
}