using System.Net;
using System.Net.Http.Json;
using BlogApplication.Domain.Entities;
using FluentAssertions;
using test.Configuration.Base;
using test.Configuration.Containers;
using test.Utils;
using test.Utils.JSON;

namespace test.BlogApplication.Api.Controllers.PostController;

[Collection(nameof(IntegrationContainerCollection))]
public class GetPost : TestConfigurationBase
{
    private readonly Post? _post;

    public GetPost(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[0])
    {
        _post = PostJson.BuildModel();
    }

    /// <summary>
    /// GetPostDataWhenReturn200Ok
    /// </summary>
    [Fact]
    public async void GetPostShouldReturnOk()
    {
        var response = await HttpClient.GetAsync($"/Post/api/posts/{_post!.Id}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    /// <summary>
    /// GetPostValidateIdAndAuthorValues
    /// </summary>
    [Fact]
    public async void GetPostShouldReturnAttributesAreAsserted()
    {
        var response = await HttpClient.GetAsync($"/Post/api/posts/{_post!.Id}");
        var result = response.Content.ReadFromJsonAsync<Post>().Result;
        _post.Id.Should().Be(result!.Id);
        _post.Author.Should().Be(result!.Author);
    }
}