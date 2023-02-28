using System.Net;
using BlogApplication.Domain.Entities;
using FluentAssertions;
using Newtonsoft.Json;
using test.Configuration.Base;
using test.Configuration.Containers;
using test.Utils;

namespace test.BlogApplication.Api.Controllers.PostController;

[Collection(nameof(IntegrationContainerCollection))]
public class GetPosts : TestConfigurationBase
{
    public GetPosts(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[0])
    {
    }

    /// <summary>
    /// GetPostsDataWhenReturn200Ok
    /// </summary>
    [Fact]
    public async void GetPostsShouldReturnOk()
    {
        var response = await HttpClient.GetAsync("/Post/api/posts");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    /// <summary>
    /// GetPostQuantityWhenReturnThreeRecords
    /// </summary>
    [Fact]
    public async void GetPostsShouldReturnThreeRecords()
    {
        var response = await HttpClient.GetAsync("/Post/api/posts");
        var result = JsonConvert.DeserializeObject<IEnumerable<Post>>(response.Content.ReadAsStringAsync().Result);
        if (result != null) Assert.Equal(3, result.Count());
    }

    /// <summary>
    /// GetPostsForValidNotEmpty
    /// </summary>
    [Fact]
    public async void GetPostsShouldReturnNotEmpty()
    {
        var response = await HttpClient.GetAsync("/Post/api/posts");
        var result = JsonConvert.DeserializeObject<IEnumerable<Post>>(response.Content.ReadAsStringAsync().Result);
        result.Should().NotBeEmpty();
    }
}