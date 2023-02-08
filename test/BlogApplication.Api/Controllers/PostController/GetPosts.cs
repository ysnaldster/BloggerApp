using System.Net;
using BlogApplication.Api;
using BlogApplication.Domain.Entities;
using BlogApplication.Infrastructure.Context;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using test.Setup;

namespace test.BlogApplication.Api.Controllers.PostController;

public class GetPosts : IClassFixture<IntegrationTestFactory<Startup, BlogApplicationContext>>
{
    private readonly IntegrationTestFactory<Startup, BlogApplicationContext> _factory;
    
    public GetPosts(IntegrationTestFactory<Startup, BlogApplicationContext> factory)
    {
        _factory = factory;
    }   
    
    /// <summary>
    /// GetPostsDataWhenReturn200Ok
    /// </summary>
    [Fact]
    public async void GetPostsShouldReturnOk()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/Post/api/posts");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    /// <summary>
    /// GetPostQuantityWhenReturnThreeRecords
    /// </summary>
    [Fact]
    public async void GetPostsShouldReturnThreeRecords()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/Post/api/posts");
        var result = JsonConvert.DeserializeObject<IEnumerable<Post>>(response.Content.ReadAsStringAsync().Result);
        if (result != null) Assert.Equal(3, result.Count());
    }
    
    /// <summary>
    /// GetPostsForValideNotEmpty
    /// </summary>
    [Fact]
    public async void GetPostsShouldReturnNotEmpty()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/Post/api/posts");
        var result = JsonConvert.DeserializeObject<IEnumerable<Post>>(response.Content.ReadAsStringAsync().Result);
        result.Should().NotBeEmpty();
    }
}