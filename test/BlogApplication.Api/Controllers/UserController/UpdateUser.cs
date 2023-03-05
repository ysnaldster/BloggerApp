using System.Net;
using System.Net.Http.Json;
using BlogApplication.Domain.Entities;
using FluentAssertions;
using tests.Configuration.Base;
using tests.Configuration.Containers;
using tests.Utils;
using tests.Utils.JSON;

namespace tests.BlogApplication.Api.Controllers.UserController;

[Collection(nameof(IntegrationContainerCollection))]
public class UpdateUser : TestConfigurationBase
{
    private readonly User? _user;
    private User? _userUpdated;
    public UpdateUser(PostgresTestContainer postgresContainer) : base(postgresContainer, DatabaseManager.Tables[1])
    {
        _user = UserJson.BuildModel(name: UserJson.NameToChange, nickname: UserJson.Nickname);
    }
    
    /// <summary>
    /// UpdateHttpStatusOkWhenUpdateUser
    /// </summary>
    [Fact]
    public async void UpdateUserShouldReturn200StatusCode()
    {
        var uri = new Uri($"{HttpClient.BaseAddress}user/api/users/{_user!.Id}");
        JsonContent content = JsonContent.Create(_user);
        var response = await HttpClient.PutAsync(uri, content);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    /// <summary>
    /// CompareUserUpdatedAndInitUser
    /// </summary>
    [Fact]
    public async void UpdateUserShouldReturnAttributesAreAsserted()
    {
        var uri = new Uri($"{HttpClient.BaseAddress}user/api/users/{_user!.Id}");
        JsonContent content = JsonContent.Create(_user);
        var response = await HttpClient.PutAsync(uri, content);
        _userUpdated = response.Content.ReadFromJsonAsync<User>().Result;
        _userUpdated!.Id.Should().Be(_user!.Id);
        _userUpdated!.Name.Should().Be(_user!.Name);
        _userUpdated!.Nickname.Should().Be(_user!.Nickname);
    }
}