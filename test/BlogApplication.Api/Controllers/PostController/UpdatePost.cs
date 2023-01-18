using System.Net;
using System.Net.Http.Json;
using BlogApplication.Api;
using BlogApplication.Domain.Entities;
using BlogApplication.Infrastructure.Context;
using FluentAssertions;
using test.Features;
using test.Setup;

namespace test.BlogApplication.Api.Controllers.PostController;

public class UpdatePost : IClassFixture<IntegrationTestFactory<Startup, BlogApplicationContext>>
{
    private readonly IntegrationTestFactory<Startup, BlogApplicationContext> _factory;
    private readonly Post? _post;
    private Post? _postUpdated;

    public UpdatePost(IntegrationTestFactory<Startup, BlogApplicationContext> factory)
    {
        _factory = factory;
        _post = PostJson.BuildModel( author : PostJson.AuthorToChange, title : PostJson.Title);
    }
    
    /// <summary>
    /// UpdateHttpStatusOkWhenUpdatePost
    /// </summary>
    [Fact]
    public async void UpdatePostShouldReturn200StatusCode()
    {
        var client = _factory.CreateClient();
        var uri = new Uri($"http://localhost:5082/Post/api/posts/{_post!.Id}");
        JsonContent content = JsonContent.Create(_post);
        var response = await client.PutAsync(uri, content);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    /// <summary>
    /// ComparePostUpdatedAndInitPost
    /// </summary>
    [Fact]
    public async void UpdatePostShouldReturnAttributesAreAsserted()
    {
        var client = _factory.CreateClient();
        var uri = new Uri($"http://localhost:5082/Post/api/posts/{_post!.Id}");
        JsonContent content = JsonContent.Create(_post);
        var response = await client.PutAsync(uri, content);
        _postUpdated = response.Content.ReadFromJsonAsync<Post>().Result;
        _postUpdated!.Id.Should().Be(_post!.Id);
        _postUpdated!.Author.Should().Be(_post!.Author);
        _postUpdated!.Title.Should().Be(_post!.Title);
    }
}