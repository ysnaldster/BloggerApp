using System.Net;
using BlogApplication.Domain.Entities;
using FluentAssertions;
using Newtonsoft.Json;
using test.Configuration.Base;
using test.Configuration.Containers;
using test.Utils;

namespace test.BlogApplication.Api.Controllers.CommentController;

[Collection(nameof(IntegrationContainerCollection))]
public class GetComments : TestConfigurationBase
{
    public GetComments(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[0])
    {
    }
    
    
    /// <summary>
    /// GetCommentsDataWhenReturn200Ok
    /// </summary>
    [Fact]
    public async void GetCommentsShouldReturnOk()
    {
        var response = await HttpClient.GetAsync("/comment/api/comments");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    /// <summary>
    /// GetCommentQuantityWhenReturnThreeRecords
    /// </summary>
    [Fact]
    public async void GetCommentsShouldReturnThreeRecords()
    {
        var response = await HttpClient.GetAsync("/comment/api/comments");
        var result = JsonConvert.DeserializeObject<IEnumerable<Comment>>(response.Content.ReadAsStringAsync().Result);
        if (result != null) Assert.Equal(3, result.Count());
    }

    /// <summary>
    /// GetCommentsForValidNotEmpty
    /// </summary>
    [Fact]
    public async void GetCommentsShouldReturnNotEmpty()
    {
        var response = await HttpClient.GetAsync("/comment/api/comments");
        var result = JsonConvert.DeserializeObject<IEnumerable<Comment>>(response.Content.ReadAsStringAsync().Result);
        result.Should().NotBeEmpty();
    }
    
}