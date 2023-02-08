/*
using System.Net;
using System.Net.Http.Json;
using BlogApplication.Api;
using BlogApplication.Domain.Entities;
using BlogApplication.Infrastructure.Context;
using FluentAssertions;
using Newtonsoft.Json;
using test.Features;
using test.Setup;

namespace test.BlogApplication.Api.Controllers;

public class PostControllerBase : IClassFixture<IntegrationTestFactory<Startup, BlogApplicationContext>>
{
    private readonly IntegrationTestFactory<Startup, BlogApplicationContext> _factory;
    private readonly Post _postCreated, _postUpdated;

    public PostControllerBase(IntegrationTestFactory<Startup, BlogApplicationContext> factory)
    {
        _factory = factory;
        _postCreated = PostJson.PostCreated();
    }
    


    
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

    [Fact]
    public async void UpdatePost()
    {
        //Toca separar estos dos tests y validar con el mismo objeto.
        var client = _factory.CreateClient();
        var post = PostJson.BuildModel( author : PostJson.AuthorToChange, title : PostJson.Title);
        var uri = new Uri($"http://localhost:5082/Post/api/posts/{post.Id}");
        JsonContent content = JsonContent.Create(post);
        var response = await client.PutAsync(uri, content);
        var result = response.Content.ReadFromJsonAsync<Post>().Result;
        result!.Id.Should().Be(post.Id.ToString());
        result!.Author.Should().Be(post.Author);
        result!.Title.Should().Be(post.Title);
    }

    [Fact]
    public async void DeletePost()
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
*/