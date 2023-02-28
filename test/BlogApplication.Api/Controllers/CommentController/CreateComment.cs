using System.Net.Http.Json;
using BlogApplication.Domain.Entities;
using FluentAssertions;
using test.Configuration.Base;
using test.Configuration.Containers;
using test.Utils;
using test.Utils.JSON;

namespace test.BlogApplication.Api.Controllers.CommentController;

[Collection(nameof(IntegrationContainerCollection))]
public class CreateComment : TestConfigurationBase
{
    private readonly Comment _commentCreated;
        
    public CreateComment(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[0])
    {
        _commentCreated = CommentJson.CommentCreated();
    }
    
    /// <summary>
    /// CreateNewCommentValidateValuesWithPostExpected
    /// </summary>
    [Fact]
    public async void CreateCommentShouldReturnAttributesAreAsserted()
    {
        var uri = new Uri($"{HttpClient.BaseAddress}comment/api/comments");
        var response = await HttpClient.PostAsync(uri, JsonContent.Create(_commentCreated));
        var result = response.Content.ReadFromJsonAsync<Comment>().Result;
        result!.Id.Should().Be(_commentCreated.Id.ToString());
        result!.Content.Should().Be(_commentCreated.Content);
    }
}