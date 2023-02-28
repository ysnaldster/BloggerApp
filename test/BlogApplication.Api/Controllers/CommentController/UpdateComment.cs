using System.Net;
using System.Net.Http.Json;
using BlogApplication.Domain.Entities;
using FluentAssertions;
using test.Configuration.Base;
using test.Configuration.Containers;
using test.Utils;
using test.Utils.JSON;

namespace test.BlogApplication.Api.Controllers.CommentController;

[Collection(nameof(IntegrationContainerCollection))]
public class UpdateComment : TestConfigurationBase
{
    private readonly Comment? _comment;
    private Comment? _commentUpdated;
    
    public UpdateComment(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[0])
    {
        _comment = CommentJson.BuildModel(content: CommentJson.Content);
    }
    
    /// <summary>
    /// UpdateHttpStatusOkWhenUpdateComment
    /// </summary>
    [Fact]
    public async void UpdateCommentShouldReturn200StatusCode()
    {
        var uri = new Uri($"{HttpClient.BaseAddress}comment/api/comments/{_comment!.Id}");
        JsonContent content = JsonContent.Create(_comment);
        var response = await HttpClient.PutAsync(uri, content);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    /// <summary>
    /// CompareCommentUpdatedAndInitComment
    /// </summary>
    [Fact]
    public async void UpdateCommentShouldReturnAttributesAreAsserted()
    {
        var uri = new Uri($"{HttpClient.BaseAddress}comment/api/comments/{_comment!.Id}");
        JsonContent content = JsonContent.Create(_comment);
        var response = await HttpClient.PutAsync(uri, content);
        _commentUpdated = response.Content.ReadFromJsonAsync<Comment>().Result;
        _commentUpdated!.Id.Should().Be(_comment!.Id);
        _commentUpdated!.Content.Should().Be(_comment!.Content);
    }
}