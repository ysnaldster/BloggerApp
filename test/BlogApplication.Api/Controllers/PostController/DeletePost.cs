using System.Net;
using System.Net.Http.Json;
using BlogApplication.Api;
using BlogApplication.Domain.Entities;
using BlogApplication.Infrastructure.Context;
using FluentAssertions;
using test.Features;
using test.Setup;

namespace test.BlogApplication.Api.Controllers.PostController;

public class DeletePost : IClassFixture<IntegrationTestFactory<Startup, BlogApplicationContext>>
{
    private readonly IntegrationTestFactory<Startup, BlogApplicationContext> _factory;

    public DeletePost(IntegrationTestFactory<Startup, BlogApplicationContext> factory)
    {
        _factory = factory;
    }   
    
    [Fact]
    public async void DeletePostShouldReturn200StatusCode()
    {
        var client = _factory.CreateClient();
        var post = PostJson.BuildModel();
        var uri = new Uri($"http://localhost:5082/Post/api/posts/{post.Id}");
        var response = await client.DeleteAsync(uri);
        var result = response.Content.ReadFromJsonAsync<Post>().Result;
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        result!.Id.Should().Be(post.Id.ToString());
    }
}