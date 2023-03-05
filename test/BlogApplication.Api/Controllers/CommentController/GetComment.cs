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
public class GetComment : TestConfigurationBase
{
    private readonly Comment? _comment;
    
    public GetComment(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[2])
    {
        _comment = CommentJson.BuildModel();
    }
    
    /// <summary>
    /// GetCommentDataWhenReturn200Ok
    /// </summary>
    [Fact]
    public async void GetCommentShouldReturnOk()
    {
        var response = await HttpClient.GetAsync($"/comment/api/comments/{_comment!.Id}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    /// <summary>
    /// GetCommentValidateIdAndContentValues
    /// </summary>
    [Fact]
    public async void GetCommentShouldReturnAttributesAreAsserted()
    {
        var response = await HttpClient.GetAsync($"/comment/api/comments/{_comment!.Id}");
        var result = response.Content.ReadFromJsonAsync<Comment>().Result;
        _comment.Id.Should().Be(result!.Id);
        _comment.Content.Should().Be(result!.Content);
    }
}
