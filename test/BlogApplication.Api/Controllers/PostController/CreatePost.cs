using System.Net;
using System.Net.Http.Json;
using BlogApplication.Api;
using BlogApplication.Domain.Entities;
using BlogApplication.Infrastructure.Context;
using FluentAssertions;
using test.Features;
using test.Setup;

namespace test.BlogApplication.Api.Controllers.PostController;

public class CreatePost : IClassFixture<IntegrationTestFactory<Startup, BlogApplicationContext>>
{
    private readonly IntegrationTestFactory<Startup, BlogApplicationContext> _factory;
    private readonly Post _postCreated;
    
    public CreatePost(IntegrationTestFactory<Startup, BlogApplicationContext> factory)
    {
        _factory = factory;
        _postCreated = PostJson.PostCreated();

    }

    /// <summary>
    /// CreateNewPostValidateValuesWithPostExpected
    /// </summary>
    [Fact]
    public async void CreatePostShouldReturnAttributesAreAsserted()
    {
        var client = _factory.CreateClient();
        var uri = new Uri("http://localhost:5082/Post/api/posts");
        var response = await client.PostAsync(uri, JsonContent.Create(_postCreated));
        var result = response.Content.ReadFromJsonAsync<Post>().Result;
        result!.Id.Should().Be(_postCreated.Id.ToString());
        result!.Author.Should().Be(_postCreated.Author);
    }
    
    /*
    /// <summary>
    /// CreateNewPostValidateStatusCode
    /// </summary>
    [Fact]
    public async void CreatePostGivePostDataShouldReturn200StatusCode()
    {
        var client = _factory.CreateClient();
        var uri = new Uri("http://localhost:5082/Post/api/posts");
        var response = await client.PostAsync(uri, JsonContent.Create(_postCreated));
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    */
}