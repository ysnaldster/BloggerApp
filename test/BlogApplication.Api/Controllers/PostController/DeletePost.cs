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
public class DeletePost :  TestConfigurationBase
{
    private readonly Post? _post;
   
    public DeletePost(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[0])
    {
        _post =  PostJson.BuildModel();

    }
    
    /// <summary>
    /// DeletePostValidateStatusCodeOk
    /// </summary>
    [Fact]
    public async void DeletePostShouldReturn200StatusCode()
    {
        var uri = new Uri($"{HttpClient.BaseAddress}Post/api/posts/{_post!.Id}");
        var response = await HttpClient.DeleteAsync(uri);
        var result = response.Content.ReadFromJsonAsync<Post>().Result;
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        result!.Id.Should().Be(_post.Id.ToString());
    }
    
}