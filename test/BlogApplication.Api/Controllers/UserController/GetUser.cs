using System.Net;
using BlogApplication.Domain.Entities;
using test.Configuration.Base;
using test.Configuration.Containers;
using test.Utils;
using test.Utils.JSON;

namespace test.BlogApplication.Api.Controllers.UserController;

[Collection(nameof(IntegrationContainerCollection))]
public class GetUser : TestConfigurationBase
{
    private readonly User? _user;

    public GetUser(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[1])
    {
        _user = UserJson.BuildModel();
    }
    
    /// <summary>
    /// GetUserDataWhenReturn200Ok
    /// </summary>
    [Fact]
    public async void GetUserShouldReturnOk()
    {
        var response = await HttpClient.GetAsync($"/user/api/users/{_user!.Id}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}