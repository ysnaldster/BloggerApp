
/*using BlogApplication.Api;
using Microsoft.AspNetCore.Mvc.Testing;

namespace test;

public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly HttpClient _httpClient;


    public UnitTest1(WebApplicationFactory<Startup> factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async void Test1()
    {
        var response2 = await _httpClient.GetAsync("/Post/api/posts");
        Assert.NotNull(response2);
    }
}
*/