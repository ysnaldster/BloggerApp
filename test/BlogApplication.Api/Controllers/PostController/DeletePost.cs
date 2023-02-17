using System.Net;
using System.Net.Http.Json;
using BlogApplication.Api;
using BlogApplication.Domain.Entities;
using BlogApplication.Infrastructure.Context;
using FluentAssertions;
using test.Clients;
using test.Configuration.Base;
using test.Configuration.Containers;
using test.Setup;
using test.Utils;

namespace test.BlogApplication.Api.Controllers.PostController;

[Collection(nameof(IntegrationContainerCollection))]
public class DeletePost :  IClassFixture<IntegrationTestFactory<Startup, BlogApplicationContext>>
{
    private readonly IntegrationTestFactory<Startup, BlogApplicationContext> _factory;
    private readonly Post? _post;
    protected readonly HttpClient HttpClient;

    
    public DeletePost(IntegrationTestFactory<Startup, BlogApplicationContext> factory)
    {
        _factory = factory;
        HttpClient = factory.CreateDefaultClient();
        HttpClient.BaseAddress = new Uri("http://localhost:5082/");
        _post =  PostJson.BuildModel();

    }
  
    /*    
    public DeletePost(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer)
    {
        
    }   
    */
    //[Fact]
    public async void DeletePostShouldReturn200StatusCode()
    {
        var uri = new Uri($"{HttpClient.BaseAddress}Post/api/posts/{_post!.Id}");
        var response = await HttpClient.DeleteAsync(uri);
        var result = response.Content.ReadFromJsonAsync<Post>().Result;
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        result!.Id.Should().Be(_post.Id.ToString());
    }


}