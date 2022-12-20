using BlogApplication.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace tests.Setup;


public abstract class IntegrationTestBase : IClassFixture<IntegrationTestFactory<Program, BlogApplicationContext>>
{
    public readonly IntegrationTestFactory<Program, BlogApplicationContext> _factory;

    public IntegrationTestBase(IntegrationTestFactory<Program, BlogApplicationContext> factory)
    {
        _factory = factory;

    }
}
