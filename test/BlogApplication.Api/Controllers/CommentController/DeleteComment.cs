using System.Net;
using System.Net.Http.Json;
using BlogApplication.Domain.Entities;
using FluentAssertions;
using tests.Configuration.Base;
using tests.Configuration.Containers;
using tests.Utils;
using tests.Utils.JSON;

namespace tests.BlogApplication.Api.Controllers.CommentController;

[Collection(nameof(IntegrationContainerCollection))]
public class DeleteComment :  TestConfigurationBase
{
    private readonly Comment? _comment;
    
    public DeleteComment(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[0])
    {
        _comment =  CommentJson.BuildModel();

    }
    
    /// <summary>
    /// DeleteCommentValidateStatusCode
    /// </summary>
    [Fact]
    public async void DeleteCommentShouldReturn200StatusCode()
    {
        var uri = new Uri($"{HttpClient.BaseAddress}comment/api/comments/{_comment!.Id}");
        var response = await HttpClient.DeleteAsync(uri);
        var result = response.Content.ReadFromJsonAsync<Comment>().Result;
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        result!.Id.Should().Be(_comment.Id.ToString());
    }
}