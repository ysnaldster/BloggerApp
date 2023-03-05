using System.Net;
using BlogApplication.Domain.Entities;
using FluentAssertions;
using Newtonsoft.Json;
using tests.Configuration.Base;
using tests.Configuration.Containers;
using tests.Utils;

namespace tests.BlogApplication.Api.Controllers.UserController;

[Collection(nameof(IntegrationContainerCollection))]
public class GetUsers : TestConfigurationBase
{
    public GetUsers(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[1])
    {
    }
    
    /// <summary>
    /// GetUsersDataWhenReturn200Ok
    /// </summary>
    [Fact]
    public async void GetUsersShouldReturnOk()
    {
        var response = await HttpClient.GetAsync("/user/api/users");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    /// <summary>
    /// GetUsersQuantityWhenReturnFourRecords
    /// </summary>
    [Fact]
    public async void GetUsersShouldReturnThreeRecords()
    {
        var response = await HttpClient.GetAsync("/user/api/users");
        var result = JsonConvert.DeserializeObject<IEnumerable<User>>(response.Content.ReadAsStringAsync().Result);
        if (result != null) Assert.Equal(3, result.Count());
    }
    
    /// <summary>
    /// GetUsersForValidNotEmpty
    /// </summary>
    [Fact]
    public async void GetUsersShouldReturnNotEmpty()
    {
        var response = await HttpClient.GetAsync("/user/api/users");
        var result = JsonConvert.DeserializeObject<IEnumerable<User>>(response.Content.ReadAsStringAsync().Result);
        result.Should().NotBeEmpty();
    }
}