using BlogApplication.Api;
using BlogApplication.Infrastructure.Context;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using test.Setup;

namespace test;

public class UnitTest1 : IClassFixture<IntegrationTestFactory<Startup, BlogApplicationContext>>
{
    private readonly IntegrationTestFactory<Startup, BlogApplicationContext> _factory;

    public UnitTest1(IntegrationTestFactory<Startup, BlogApplicationContext> factory)
    {
        _factory = factory;
    }
    
    [Fact]
    public async void Test1()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/test/api");
        //Hello World
        Assert.NotNull(response);
    }
    
}