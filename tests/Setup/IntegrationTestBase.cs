using BlogApplication.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace tests.Setup;

/*
public class IntegrationTestBase : IClassFixture<IntegrationTestFactory<Program, BlogApplicationContext>>
{
    public readonly IntegrationTestFactory<Program, BlogApplicationContext> Factory;
    //public readonly BlogApplicationContext DbContext;

    public IntegrationTestBase(IntegrationTestFactory<Program, BlogApplicationContext> factory)
    {
        Factory = factory;
        //var scope = factory.Services.CreateScope();
        //DbContext = scope.ServiceProvider.GetRequiredService<BlogApplicationContext>();
    }
}
*/