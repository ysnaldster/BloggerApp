﻿using System.Net.Http.Json;
using BlogApplication.Domain.Entities;
using FluentAssertions;
using tests.Configuration.Base;
using tests.Configuration.Containers;
using tests.Utils;
using tests.Utils.JSON;

namespace tests.BlogApplication.Api.Controllers.UserController;

[Collection(nameof(IntegrationContainerCollection))]
public class CreateUser : TestConfigurationBase
{
    private readonly User _userCreated;
    public CreateUser(PostgresTestContainer postgresTestContainer) : base(postgresTestContainer, DatabaseManager.Tables[0])
    {
        _userCreated = UserJson.UserCreated();
    }
    
    /// <summary>
    /// CreateNewUserValidateValuesWithUserExpected
    /// </summary>
    [Fact]
    public async void CreateUserShouldReturnAttributesAreAsserted()
    {
        var uri = new Uri($"{HttpClient.BaseAddress}user/api/users");
        var response = await HttpClient.PostAsync(uri, JsonContent.Create(_userCreated));
        var result = response.Content.ReadFromJsonAsync<User>().Result;
        result!.Id.Should().Be(_userCreated.Id.ToString());
        result!.Name.Should().Be(_userCreated.Name);
    }
}