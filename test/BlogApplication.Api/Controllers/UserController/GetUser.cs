using System.Net;
using BlogApplication.Domain.Entities;
using tests.Configuration.Base;
using tests.Configuration.Containers;
using tests.Utils;
using tests.Utils.JSON;

namespace tests.BlogApplication.Api.Controllers.UserController;

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