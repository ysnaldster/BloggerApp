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
public class DeleteComment :  TestConfigurationBase
{
    private readonly Comment? _comment;
    
    public DeleteComment(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[0])
    {
        _comment =  CommentJson.BuildModel();

    }
    
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