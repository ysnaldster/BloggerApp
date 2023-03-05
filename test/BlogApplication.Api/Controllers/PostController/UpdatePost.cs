using System.Net;
using System.Net.Http.Json;
using BlogApplication.Domain.Entities;
using FluentAssertions;
using tests.Configuration.Base;
using tests.Configuration.Containers;
using tests.Utils;
using tests.Utils.JSON;

namespace tests.BlogApplication.Api.Controllers.PostController;

[Collection(nameof(IntegrationContainerCollection))]
public class UpdatePost : TestConfigurationBase
{
    private readonly Post? _post;
    private Post? _postUpdated;

    public UpdatePost(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[0])
    {
        _post = PostJson.BuildModel(author: PostJson.AuthorToChange, title: PostJson.Title);
    }

    /// <summary>
    /// UpdateHttpStatusOkWhenUpdatePost
    /// </summary>
    [Fact]
    public async void UpdatePostShouldReturn200StatusCode()
    {
        var uri = new Uri($"{HttpClient.BaseAddress}Post/api/posts/{_post!.Id}");
        JsonContent content = JsonContent.Create(_post);
        var response = await HttpClient.PutAsync(uri, content);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    /// <summary>
    /// ComparePostUpdatedAndInitPost
    /// </summary>
    [Fact]
    public async void UpdatePostShouldReturnAttributesAreAsserted()
    {
        var uri = new Uri($"{HttpClient.BaseAddress}Post/api/posts/{_post!.Id}");
        JsonContent content = JsonContent.Create(_post);
        var response = await HttpClient.PutAsync(uri, content);
        _postUpdated = response.Content.ReadFromJsonAsync<Post>().Result;
        _postUpdated!.Id.Should().Be(_post!.Id);
        _postUpdated!.Author.Should().Be(_post!.Author);
        _postUpdated!.Title.Should().Be(_post!.Title);
    }
}