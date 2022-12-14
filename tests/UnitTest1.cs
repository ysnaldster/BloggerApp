using System.Net.Http.Json;
using BlogApplication.Domain.Entities;
using BlogApplication.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using tests.Setup;

namespace tests;

public class UnitTest1 : IntegrationTestFactory
{
    private readonly IntegrationTestFactory _integrationTestFactory;

    public UnitTest1(IntegrationTestFactory integrationTestFactory)
    {
        _integrationTestFactory = integrationTestFactory;
    }

    [Fact]
    public async void Test1()
    {
        //var client1 = _integrationTestFactory.CreateClient();
        var client = _integrationTestFactory.CreateClient();
        //var result = await client.GetFromJsonAsync<IEnumerable<Post>>("/post/api/posts");
        Assert.NotNull(client);
    }
}