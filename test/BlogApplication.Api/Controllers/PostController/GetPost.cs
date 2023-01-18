using System.Net;
using System.Net.Http.Json;
using BlogApplication.Api;
using BlogApplication.Domain.Entities;
using BlogApplication.Infrastructure.Context;
using FluentAssertions;
using test.Features;
using test.Setup;

namespace test.BlogApplication.Api.Controllers.PostController;

public class GetPost : IClassFixture<IntegrationTestFactory<Startup, BlogApplicationContext>>
{
    private readonly IntegrationTestFactory<Startup, BlogApplicationContext> _factory;
    private readonly Post? _post;

    public GetPost(IntegrationTestFactory<Startup, BlogApplicationContext> factory)
    {
        _factory = factory;
        _post = PostJson.BuildModel();
    }
    
    /// <summary>
    /// GetPostDataWhenReturn200Ok
    /// </summary>
    [Fact]
    public async void GetPostShouldReturnOk()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/Post/api/posts/{_post!.Id}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    /// <summary>
    /// GetPostValidateIdAndAuthorValues
    /// </summary>
    [Fact]
    public async void GetPostShouldReturnAttributesAreAsserted()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"/Post/api/posts/{_post!.Id}");
        var result =response.Content.ReadFromJsonAsync<Post>().Result;
        _post.Id.Should().Be(result!.Id);
        _post.Author.Should().Be(result!.Author);
    }
}