using System.Net;
using test.Configuration.Containers;

namespace test.BlogApplication.Api.Controllers2;

[Collection(nameof(IntegrationContainerCollection))]
public class PostControllerTest : ControllerTestBase
{
    public PostControllerTest(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer)
    {
    }
    
    [Fact]
    public async void GetPostsShouldReturnOk()
    {
        var response = await HttpClient.GetAsync("/Post/api/posts");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}